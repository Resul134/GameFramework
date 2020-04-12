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
            IsDead = false;
        }
        



        public double AttackPlayer(World mapPlayer)
        {
            if (IsDead == false && mapPlayer.Player.hitPoints > 0)  
            {
                if (Weapon.Damage < mapPlayer.Player.hitPoints && AttackType == TypeOfAttack.Melee)
                {
                    return mapPlayer.Player.hitPoints = recieveDamage(Weapon.Damage, TypeOfAttack.Melee);
                }
                if (Weapon.Damage < mapPlayer.Player.hitPoints && AttackType == TypeOfAttack.Magic)
                {
                    return mapPlayer.Player.hitPoints = recieveDamage(Weapon.Damage, TypeOfAttack.Magic);
                }
                if (Weapon.Damage < mapPlayer.Player.hitPoints && AttackType == TypeOfAttack.Ranged)
                {
                    return mapPlayer.Player.hitPoints = recieveDamage(Weapon.Damage, TypeOfAttack.Ranged);
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

        public bool creatureMoverandom(Direction newDirect = 0)
        {
            return creatureRandomMove();
        }

        private bool creatureRandomMove()
        {
            handleMovements();

            return true;
        }

        private void handleMovements()
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
        }
    }
}
