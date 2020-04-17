using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.AbstractClasses;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class Entities : EntityAbs
    {
        

        public Entities(int positionX, int positionY, Weapon weaponCreature, Armor armor, TypeOfAttack attackType, double hp, string name) : base(name, hp, weaponCreature, armor, positionX, positionY, attackType)
        {
            Direction = Direction.Up;
            IsDead = false;
        }
        



        public double AttackPlayer(World mapPlayer)
        {
            while (IsDead == false && mapPlayer.Player.CurrentHealth > 0)  
            {
                if (Weapon.Damage < mapPlayer.Player.CurrentHealth && AttackType == TypeOfAttack.Melee)
                {
                    return mapPlayer.Player.CurrentHealth -= CalcDamage(Weapon.Damage, TypeOfAttack.Melee);
                }
                if (Weapon.Damage < mapPlayer.Player.CurrentHealth && AttackType == TypeOfAttack.Magic)
                {
                    return mapPlayer.Player.CurrentHealth -= CalcDamage(Weapon.Damage, TypeOfAttack.Magic);
                }
                if (Weapon.Damage < mapPlayer.Player.CurrentHealth && AttackType == TypeOfAttack.Ranged)
                {
                    return mapPlayer.Player.CurrentHealth -= CalcDamage(Weapon.Damage, TypeOfAttack.Ranged);
                }
            }

            return 0;
        }

        public void resetCreatureHealth()
        {
            hitPoints = 120;
        }

        

        private double CalcDamage(double recieveDamage, TypeOfAttack Typeattack)
        {
            if (Typeattack == TypeOfAttack.Magic)
            {
                if (recieveDamage != 0)
                {
                    return CurrentHealth -= recieveDamage;
                }
 
            }

            if (Typeattack == TypeOfAttack.Melee)
            {
                if (recieveDamage != 0)
                {
                    return CurrentHealth -= recieveDamage;
                }

            }
            if (Typeattack == TypeOfAttack.Ranged)
            {
                if (recieveDamage !=  0)
                {
                    return CurrentHealth -= recieveDamage;
                }

            }

            return hitPoints;
        }

        public void EquipWeapon(Weapon newGear)
        {
            if (newGear.Damage > Weapon.Damage)
            {
                Weapon = newGear;
            }
        }

        public void EquipArmor(Armor newArmor)
        {
            if (newArmor.Defense > ArmorType.Defense)
            {
                ArmorType = newArmor;
            }
            Console.WriteLine("The item you're equipping has less defence");

        }

        public bool MonsterInteractionsInWorldWeapons(World world)
        {
            Random rand = new Random();
            CreatureMoveRandom(world, Direction = (Direction) rand.Next(1, 4)); // or 0?

            var weapons = world.weaponsList;
            
                foreach (var w in weapons)
                {
                    var interact = world.CreatureList.Where(x =>
                        x.FixedPositionX == w.FixedPositionX && x.FixedPositionY == w.FixedPositionY);

                    world._notify("Checking");
                    if (interact.Count() == 0)
                    {
                        return false;
                    }


                    //Use FirstOrDefault() when you know that you will need to check whether
                    //there was an element or not. In other words, if you know it is legal for the sequence to be empty, which can be possible.
                    var weaponC = weapons.FirstOrDefault();


                    EquipWeapon(weaponC);
                
                    world._notify("Succesful");

                    return true;

                }


                return false;

            

        }

        public void setCreatureHPandDamage(EntityAbs creature, int damageDemod, int hpDemod)
        {
            if (creature.IsDead == false) 
            {
                creature.hitPoints = hpDemod;
                creature.Weapon.Damage = hpDemod;
            }

            Console.WriteLine("Creature is dead");
            
            

        }

        



        public bool CreatureMoveRandom(World world, Direction newDirect = 0)
        {
            return handleMovements(world);
        }

        

        private bool handleMovements(World map)
        {
            Random rand = new Random();
            int newPosX = FixedPositionX;
            int newPosY = FixedPositionY;

            var y = rand.Next(1, 4);


            switch (y)
            {
                case 1:
                    newPosX--;
                    break;
                case 2:
                    newPosY++;
                    break;
                case 3:
                    newPosX++;
                    break;
                case 4:
                    newPosX--;
                    break;
            }

            if (newPosX > map.Width || newPosX < 0) return false;
            if (newPosY > map.Height || newPosY < 0) return false;

            

            FixedPositionY = newPosY;
            FixedPositionX = newPosX;

            return true;
        }
    }
}
