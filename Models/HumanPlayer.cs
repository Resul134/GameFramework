using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.AbstractClasses;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class HumanPlayer : CreatureAbs
    {
        public HumanPlayer(string desctription, double hitpoints, Weapon weapon, Armor armor, int fixedPositionX, int fixedPositionY, TypeOfAttack attackType) : base(desctription, hitpoints, weapon, armor, fixedPositionX, fixedPositionY, attackType)
        {
            Direction = Direction.Down;
            IsDead = false;
            CurrentHealth = 160;
        }

        //Unfinished maybe convert method to bool, and check for if hitPoints under 0 return IsDead true?
        public double AttackCreature(HumanPlayer player, CreatureAbs creatureOP)
        {
            if (creatureOP.IsDead == false && player.IsDead == false)
            {
                if (player.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Melee)
                {
                    return creatureOP.CurrentHealth = recieveDamage(player.Weapon.Damage, TypeOfAttack.Melee);
                }
                if (player.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Magic)
                {
                    return creatureOP.CurrentHealth = recieveDamage(player.Weapon.Damage, TypeOfAttack.Magic);
                }
                if (player.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Ranged)
                {
                    return creatureOP.CurrentHealth = recieveDamage(player.Weapon.Damage, TypeOfAttack.Ranged);
                }
            }

            return hitPoints;
        }

        public void PlayerMovements(World environment, Direction newDirect)
        {


            int newPosX = FixedPositionX;
            int newPosY = FixedPositionY;

            switch (newDirect)
            {
                case Direction.Up:
                    newPosX--;
                    break;
                case Direction.Left:
                    newPosY++;
                    break;
                case Direction.Down:
                    newPosX++;
                    break;
                case Direction.Right:
                    newPosX--;
                    break;

            }

            Direction = newDirect;



        }


        public double recieveDamage(double recieveDamage, TypeOfAttack Typeattack)
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
                if (recieveDamage != 0)
                {
                    return CurrentHealth -= recieveDamage;
                }

            }

            return hitPoints;
        }

        //TEST, to see if I can move the methods from world to it's respectable class.
        public void BuffPlayer_IF_Potion_Encountered(World potion, double healthModifier, double damageModifier)
        {
            foreach (var p in potion.potionList)
            {
                if (FixedPositionX == p.FixedPositionX && FixedPositionY == p.FixedPositionY)
                {
                    CurrentHealth += healthModifier;
                    Weapon.Damage += damageModifier;

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

        public void LootArmor(Armor newArmor)
        {
            if (newArmor.Defense > ArmorType.Defense)
            {
                ArmorType = newArmor;
            }

        }

        public void LootPotion(Potion potion, double Modifier)
        {
            if (FixedPositionX == potion.FixedPositionX && FixedPositionY == potion.FixedPositionY)
            {
                hitPoints += Modifier;
            }
        }

        public void Action(World map, Direction direction)
        {
            PlayerMovements(map, direction);
        }

        public void ResetPlayersHealth()
        {
            hitPoints = 160;
        }


        





    }
}
