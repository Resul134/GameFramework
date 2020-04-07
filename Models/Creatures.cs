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
    public class Creatures : CreatureAbs
    {
        

        public Creatures(int positionX, int positionY, Weapon weaponCreature, Armor armor, TypeOfAttack attackType) : base("Goblin", 120, weaponCreature, armor, positionX, positionY, attackType)
        {
           
            StateOfLife = LivingState.Alive;

        }
        



        public void AttackPlayer(CreatureAbs creatureOP, HumanPlayer player)
        {
            if (creatureOP.IsDead == false && player.IsDead == false)  
            {
                if (creatureOP.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Melee)
                {
                    recieveDamage(creatureOP.Weapon.Damage, TypeOfAttack.Melee);
                }
                if (creatureOP.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Magic)
                {
                    recieveDamage(creatureOP.Weapon.Damage, TypeOfAttack.Magic);
                }
                if (creatureOP.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Ranged)
                {
                    recieveDamage(creatureOP.Weapon.Damage, TypeOfAttack.Ranged);
                }
            }
        }

        

        public void recieveDamage(double recieveDamage, TypeOfAttack Typeattack)
        {
            if (Typeattack == TypeOfAttack.Magic)
            {
                if (recieveDamage <= 40)
                {
                    hitPoints -= recieveDamage;
                }
                else
                {
                    Console.WriteLine("Magic can't hit harder than 40");
                }
            }

            if (Typeattack == TypeOfAttack.Melee)
            {
                if (recieveDamage <= 60)
                {
                    hitPoints -= recieveDamage;
                }
                else
                {
                    Console.WriteLine("Melee cant hit harder than 60");
                }
            }
            if (Typeattack == TypeOfAttack.Ranged)
            {
                if (recieveDamage <= 50)
                {
                    hitPoints -= recieveDamage;
                }
                else
                {
                    Console.WriteLine("Ranged cant hit harder than 60");
                }
            }
        }

        public void LootWeapon(Weapon newGear)
        {
            if (newGear.Damage > Weapon.Damage)
            {
                Weapon = newGear;
            }
        }

        public void Loot(Armor newArmor)
        {
            if (newArmor.Defense > ArmorType.Defense)
            {
                ArmorType = newArmor;
            }

        }

        public void PlayerMovements(World environment)
        {
            //Recursive
            if (Console.ReadKey().Key == ConsoleKey.W)
            {
                if (FixedPositionX - 1 != -1) FixedPositionY -= 1;
                else PlayerMovements(environment);

            }
            if (Console.ReadKey().Key == ConsoleKey.A)
            {
                if (FixedPositionX - 1 != -1) FixedPositionX -= 1;
                else PlayerMovements(environment);

            }
            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                if (FixedPositionX - 1 != environment.Height) FixedPositionX -= 1;
                else PlayerMovements(environment);

            }
            if (Console.ReadKey().Key == ConsoleKey.D)
            {
                if (FixedPositionX - 1 != environment.Height) FixedPositionX -= 1;
                else PlayerMovements(environment);

            }




        }

        public void Event(World map)
        {
            PlayerMovements(map);
        }



    }
}
