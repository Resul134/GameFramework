using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibMandatory.AbstractClasses;
using LibMandatory.CreatureStates;
using LibMandatory.Factories;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class World
    {
        public event NotificationHandler OnNotification;
        public delegate void NotificationHandler(object sender, NotificationEventArg args);
        public int Height { get; set; }
        public int Width { get; set; }
        public string Gameborder = "|-----------------------|";
        public HumanPlayer Player { get; set; }
        

        public List<IWeapon> WeaponsList { get; set; }
        public WeaponFactory WeaponFactory = new WeaponFactory();

        public EventHandler OnChanged;


        public List<Armor> ArmorList { get; set; }
        public ArmorFactory ArmorFactory = new ArmorFactory();

        public List<Potion> potionList { get; set; }
        public PotionFactory PotionFactory = new PotionFactory();

        //Decorator? ICreate is called, it accepts the interface as an Entity class, because EntityAbs derives from ICreature, and 
        //Weapon derives from EntityAbs
        public List<ICreature> CreatureList { get; set; }
        public CreatureFactory CreatureFactory  = new CreatureFactory();

        public List<Spikes> SpikeList { get; set; }
        public spikeFactory SpikeFactory = new spikeFactory();


        public World(int height, int width)
        {

            Height = height;
            Width = width;
            Player = new HumanPlayer("Arthur", 120, new Weapon(TypeOfAttack.Melee, 50, "sword", -1,-1),
                new Armor(ArmorType.Plate,"Plate", 30, -1,-1),1,1, TypeOfAttack.Melee  );
            WeaponsList = new List<IWeapon>();
            

            ArmorList = new List<Armor>();
           

            potionList = new List<Potion>();
            

            CreatureList = new List<ICreature>();

            SpikeList = new List<Spikes>();



            
            Parallel.Invoke(() => new Thread(playerMovementHandler).Start()  );
               
            

           
        }

       

        private void MakeMap()
        {

            Console.Clear();
            char[,] playground = new char[Height, Width];
            

            Console.WriteLine(Gameborder);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Player.FixedPositionX == i && Player.FixedPositionY == j)
                    {
                        playground[i, j] = 'P';
                    }
                    else playground[i, j] = '*';

                    foreach (var w in WeaponsList)
                    {
                        if (w.FixedPositionX == i && w.FixedPositionY == j)
                        {
                            playground[i, j] = 'W';
                        }
                    }

                    foreach (var A in ArmorList)
                    {
                        if (A.FixedPositionX == i && A.FixedPositionY == j)
                        {
                            playground[i, j] = 'A';
                        }
                    }

                    foreach (var P in potionList)
                    {
                        if (P.FixedPositionX == i && P.FixedPositionY == j)
                        {
                            playground[i, j] = 'O';
                        }
                    }

                    foreach (var C in CreatureList)
                    {
                        if (C.FixedPositionX == i && C.FixedPositionY == j)
                        {
                            playground[i, j] = 'C';
                        }
                    }

                    foreach (var S in SpikeList)
                    {
                        if (S.FixedPositionX == i && S.FixedPositionY == j)
                        {
                            playground[i, j] = 'S';
                        }
                    }

                    Console.WriteLine($"|{playground[i,j]}|");

                   

                }

                
            }

            Console.WriteLine(Gameborder);

            
        }

        public void playerMovementHandler()
        {

            while (true)
            {
                ConsoleKeyInfo playerInput = Console.ReadKey();


                if (playerInput.Key ==  ConsoleKey.W)
                {
                    Player.Action(this, Direction.Up);
                }

                if (playerInput.Key == ConsoleKey.A)
                {
                    Player.Action(this, Direction.Left);
                }
                if (playerInput.Key == ConsoleKey.S)
                {
                    Player.Action(this, Direction.Down);
                }
                if (playerInput.Key == ConsoleKey.D)
                {
                    Player.Action(this, Direction.Right);
                }

            }
            
        }


        


        public void AddWeapontoWorld(TypeOfAttack attackType, double damage, string description, int positionX, int positionY)
        {
            WeaponsList.Add(WeaponFactory.GenerateWeapon(attackType, damage, description,positionX,positionY));

            OnEventChanged(EventArgs.Empty);
        }

        public void RemoveWeaponFromWorld(Weapon weapon)
        {
            WeaponsList.Remove(weapon);
        }

        public void AddArmortoWorld(ArmorType armorType, string armorname, double defense, int positionX, int positionY)
        {
            ArmorList.Add(ArmorFactory.getTypeOfArmor(armorType, armorname, defense, positionX,positionY));
        }

        public void RemoveArmor(Armor armor)
        {
            if (armor != null)
            {
                ArmorList.Remove(armor);
            }
            throw new NullReferenceException("Armor is not filled out");
            
        }


        public void AddPotionToWorldRandomPosition(string potionName, int positionX, int positionY)
        {
            //Observer
            potionList.Add(PotionFactory.makePotions(positionX, positionY, potionName));
            OnEventChanged(EventArgs.Empty);

            //EventArgs.Empty is an instance of the Null object pattern.

            //Basically having an object representing "no value" to avoid checking for null when using it.
        }


        public void RemovePotion(Potion potion)
        {
            potionList.Remove(potion);
        }


        public void AddCreaturesToWorld(Entities entity, Weapon weapon, Armor armor,
            TypeOfAttack attackType, int positionX, int positionY, double hitPoints, string name)
        {
            CreatureList.Add(CreatureFactory.makeCreature(positionX, positionY,weapon, armor, attackType, hitPoints, name));

        }

        public void RemoveCreaturFromWorld(Entities entity)
        {
            if (CreatureList.Count > 0 && CreatureList.Count != 0)
            {
                CreatureList.Remove(entity);
            }
            

        }

        //Experimental
        public void DecreaseAllCreaturesHP(int hp)
        {
            try
            {

                    CreatureList.Where(x => x.hitPoints > 0).ToList().ForEach(s => s.hitPoints = hp);
       
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public void ReducePlayerArmor(double armorDemod)
        {
            if (Player != null)
            {
                foreach (var c in CreatureList)
                {
                    if (c.AttackType == TypeOfAttack.Magic)
                    {
                        Player.ArmorType.Defense -= armorDemod;
                    }
                }
            }
        }

        public void BuffPlayer_IF_Potion_EncounteredWorld(double healthModifier, double damageModifier)
        {
            foreach (var p in potionList)
            {
                if (Player.FixedPositionX == p.FixedPositionX && Player.FixedPositionY == p.FixedPositionY)
                {
                    Player.CurrentHealth += healthModifier;
                    Player.Weapon.Damage += damageModifier;

                }
            }
        }


        public void PrintCreaturesWithName(string name)
        {
            if (name != null)
            {
                //Obeserver pattern experimental
                _notify($"Checking '{name}'...");
                var selectedCreatures = CreatureList.Where(x => x.Description == name).ToList();

                if (selectedCreatures.Count > 0)
                {
                    _notify($"We found a match!");
                    foreach (var s in selectedCreatures)
                    {
                        Console.WriteLine("Creature names: " + s.Description);

                    }

                }
                throw new ArgumentException("Something went wrong bro");
                
            }
            throw new NullReferenceException("Name cannot be empty");
            
        }

        public void addSpikes(int positionX, int positionY, string description)
        {
            if (positionX != null && positionY != null)
            {
                SpikeList.Add(SpikeFactory.makeSpikes(positionX,positionY,description));
            }
            throw new NullReferenceException("Parameters must be filled");
            
        }

        

        public void HumanPickUpsWeapon(HumanPlayer Player, Weapon weapon)
        {
            if (!WeaponsList.Contains(weapon)) return;

            Player.EquipWeapon(weapon);

        }

        public void HumanPickUpsArmor(HumanPlayer Player, Armor armor)
        {
            if (!ArmorList.Contains(armor)) return;

            Player.EquipArmor(armor);

        }

        public void CreaturePicksUpWeapon(Entities entity, Weapon weapon)
        {
            if (!WeaponsList.Contains(weapon)) return;
            
            entity.EquipWeapon(weapon);
        }


        public void CreaturePicksUpArmor(Entities entity, Armor armor)
        {
            if (!ArmorList.Contains(armor)) return;

            entity.EquipArmor(armor);
        }

        public void removeSpikes(Spikes spikes)
        {
            if (spikes != null)
            {
                SpikeList.Remove(spikes);
            }
        }

        //Classic example of a decorator, could change ICreature to Entities.
        public void HumanReactionOnMonster(ICreature c)
        {
            if (c != null)
            {
                Player.AttackCreature(Player, c);
            }
            throw new NullReferenceException("Parameter is null");
            
        }

        public void MonsterReactionOnHuman(World d, Entities c)
        {
            c.AttackPlayer(d);
        }

        public void AddDemonForm()
        {
            Random rand = new Random();
            CreautureStates state = new CreautureStates();
            string sDemon = "Demon";
            foreach (var c in CreatureList)
            {
                if (c.Description == "Demon")
                {
                    ICreature demon = state.SPawnDemon(rand.Next(0,9),rand.Next(0,9));
                    CreatureList.Add(demon);
                }
                throw new ArgumentException("No demons");
            }
        }


        public void WhatIsCreatureDmg()
        {
            var emmy = CreatureList.Select(x => x.Weapon.Damage);

            foreach (var e in emmy)
            {
                Console.WriteLine($"All creatures dmg: {e}");
            }
        }

        public void SpikesEncounteredByPlayerDamage()
        {
            if (Player != null)
            {
                foreach (var s in SpikeList)
                {
                    if (Player.FixedPositionX == s.FixedPositionX && Player.FixedPositionY == s.FixedPositionY)
                    {
                        double dmgRecieved =  Player.CurrentHealth - s.Damage;
                        Console.WriteLine($"Damage recieved {dmgRecieved}");
                    }
                }
            }
            
        }
        //Observer, 
        public void OnEventChanged(EventArgs s)
        {
            EventHandler handler = OnChanged;
            if (handler != null)
            {
                handler.Invoke(this, s);
            }
            throw new NullReferenceException("Handler is null");
            
        }

        //Observer
        public void _notify(string message)
        {
            if (OnNotification != null)
            {
                OnNotification.Invoke(this, new NotificationEventArg
                {
                    Message = message
                });
            }
        }

        



    }

    
    
    
}

