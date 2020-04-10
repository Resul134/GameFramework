using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibMandatory.Factories;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class World
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public HumanPlayer Player { get; set; }

        public List<Weapon> weaponsList { get; set; }
        public WeaponFactory WeaponFactory { get; set; }

        public List<Armor> armorList { get; set; }
        public ArmorFactory ArmorFactory { get; set; }

        public List<Potion> potionList { get; set; }
        public PotionFactory PotionFactory { get; set; }


        public List<Creatures> creatureList { get; set; }
        public CreatureFactory CreatureFactory { get; set; }


        public World(int height, int width)
        {

            Height = height;
            Width = width;
            Player = new HumanPlayer("Arthur", 120, new Weapon(TypeOfAttack.Melee, 50, "sword", -1,-1),
                new Armor(ArmorType.Plate,"Plate", 30, -1,-1),1,1, TypeOfAttack.Melee  );
            weaponsList = new List<Weapon>();
            WeaponFactory = new WeaponFactory();

            armorList = new List<Armor>();
            ArmorFactory = new ArmorFactory();

            potionList = new List<Potion>();
            PotionFactory = new PotionFactory();

            creatureList = new List<Creatures>();
            CreatureFactory = new CreatureFactory();

            Parallel.Invoke(playerMovementHandler, delegate()
            {
                Console.WriteLine($"playermovement");
            });

           
        }

       

        private void MakeMap(int height, int width)
        {
            char[,] playground = new char[Height, Width];


            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (Player.FixedPositionX == i && Player.FixedPositionY == j)
                    {
                        playground[i, j] = 'P';
                    }
                    else playground[i, j] = '*';

                    foreach (var w in weaponsList)
                    {
                        if (w.FixedPositionX == i && w.FixedPositionY == j)
                        {
                            playground[i, j] = 'W';
                        }
                    }

                    foreach (var A in armorList)
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

                    foreach (var C in creatureList)
                    {
                        if (C.FixedPositionX == i && C.FixedPositionY == j)
                        {
                            playground[i, j] = 'C';
                        }
                    }

                }
            }

            
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


        


        public void addWeapontoWorld(TypeOfAttack attackType, double damage, string description)
        {
            Random rand = new Random();
            weaponsList.Add(WeaponFactory.GenerateWeapon(attackType, damage, description,rand.Next(0,7),rand.Next(0,7)));
        }

        public void removeWeapon(Weapon weapon)
        {
            weaponsList.Remove(weapon);
        }

        public void addArmortoWorld(ArmorType armorType, string armorname, double defense)
        {
            Random rand = new Random();
            armorList.Add(ArmorFactory.getTypeOfArmor(armorType, armorname, defense, rand.Next(0,10),rand.Next(0,10)));
        }

        public void removeArmor(Armor armor)
        {
            armorList.Remove(armor);
        }


        public void addPotionToWorld(string potionName)
        {
            Random rand = new Random();
            potionList.Add(PotionFactory.makePotions(rand.Next(0, 4), rand.Next(0, 4), potionName));
        }


        public void removePotion(Potion potion)
        {
            potionList.Remove(potion);
        }

    }









}

