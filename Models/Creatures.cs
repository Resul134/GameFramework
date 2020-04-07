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
            Direction = Direction.Up;
            StateOfLife = LivingState.Alive;

        }
        



        public double AttackPlayer(CreatureAbs creatureOP, HumanPlayer player)
        {
            if (creatureOP.IsDead == false && player.IsDead == false)  
            {
                if (creatureOP.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Melee)
                {
                    return player.hitPoints = recieveDamage(creatureOP.Weapon.Damage, TypeOfAttack.Melee);
                }
                if (creatureOP.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Magic)
                {
                    return player.hitPoints = recieveDamage(creatureOP.Weapon.Damage, TypeOfAttack.Magic);
                }
                if (creatureOP.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Ranged)
                {
                    return player.hitPoints = recieveDamage(creatureOP.Weapon.Damage, TypeOfAttack.Ranged);
                }
            }

            return 0;
        }

        

        public double recieveDamage(double recieveDamage, TypeOfAttack Typeattack)
        {
            if (Typeattack == TypeOfAttack.Magic)
            {
                if (recieveDamage <= 40)
                {
                    return hitPoints -= recieveDamage;
                }
 
            }

            if (Typeattack == TypeOfAttack.Melee)
            {
                if (recieveDamage <= 60)
                {
                    return hitPoints -= recieveDamage;
                }

            }
            if (Typeattack == TypeOfAttack.Ranged)
            {
                if (recieveDamage <= 50)
                {
                    return hitPoints -= recieveDamage;
                }

            }

            return hitPoints;
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

        public bool creatureMoverandom(World environment, Direction newDirect = 0)
        {
            return creatureRandomMove(environment);
        }

        private bool creatureRandomMove(World environment)
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

            return true;






        }





    }
}
