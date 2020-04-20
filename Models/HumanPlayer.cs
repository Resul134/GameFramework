using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.AbstractClasses;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class HumanPlayer : EntityAbs
    {
        public HumanPlayer(string desctription, double hitpoints, Weapon weapon, Armor armor, int fixedPositionX, int fixedPositionY, TypeOfAttack attackType) : base(desctription, hitpoints, weapon, armor, fixedPositionX, fixedPositionY, attackType)
        {
            Direction = Direction.Down;
            IsDead = false;
            CurrentHealth = 160;
        }

        //Unfinished maybe convert method to bool, and check for if hitPoints under 0 return IsDead true?
        //Decorator, using ICreature as it is accepted as a class.
        public void AttackCreature(HumanPlayer player, ICreature entityOp)
        {
            while (entityOp.IsDead == false && player.IsDead == false )
            {
                //New if statement, not sure if I'll keep it.
                if (player.FixedPositionX == entityOp.FixedPositionX && player.FixedPositionY == entityOp.FixedPositionY)
                {
                    //Depending on the units armor, the damage will either amplifiy or get a reduction
                    if (player.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Melee)
                    {
                        entityOp.CurrentHealth -= calcDamage(player.Weapon.Damage, TypeOfAttack.Melee);
                        Console.WriteLine($"Monster has taken dmg!: {entityOp.CurrentHealth} hp left");
                    }
                    if (player.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Magic)
                    {
                        entityOp.CurrentHealth -= calcDamage(player.Weapon.Damage, TypeOfAttack.Magic);
                        Console.WriteLine($"Monster has taken dmg!: {entityOp.CurrentHealth} hp left");
                    }
                    if (player.Weapon.Damage < hitPoints && AttackType == TypeOfAttack.Ranged)
                    {
                        entityOp.CurrentHealth -= calcDamage(player.Weapon.Damage, TypeOfAttack.Ranged);
                        Console.WriteLine($"Monster has taken dmg!: {entityOp.CurrentHealth} hp left");
                    }

                    throw new ArgumentException("No interactions were possible");
                }
                throw new ArgumentException("Player did not encounter monster");
                
            }

            
        }

        public bool PlayerMovements(World environment, Direction newDirect)
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


            if (newPosX > environment.Width || newPosX < 0) return false;
            if (newPosY > environment.Height || newPosY < 0) return false;


            
            FixedPositionX = newPosX;
            FixedPositionY = newPosY;

            return true;



        }

        //Template methode, proving that both human and entity has access to the method
        public void WhatIsMyDmg(double dmg)
        {
            WhatIsMyDmg(dmg);
        }


        private double calcDamage(double recieveDamage, TypeOfAttack Typeattack)
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

        public void DecreaseCreatureDefenses(World creatures, double defenseDemod)
        {

            creatures.CreatureList.Where(x=> x.ArmorType.Defense > 0).ToList().ForEach(s=> s.ArmorType.Defense = defenseDemod);

        }

        public void EquipWeapon(IWeapon newGear)
        {
            if (newGear.Damage > Weapon.Damage)
            {
                Weapon = (Weapon)newGear;
            }
        }

        public void EquipArmor(Armor newArmor)
        {
            if (newArmor.Defense > ArmorType.Defense)
            {
                ArmorType = newArmor;
            }

        }

        public void DrinkPotion(Potion potion, double Modifier)
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
