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
    public class Enitities : EnitityAbs
    {
        

        public Enitities(int positionX, int positionY, Weapon weaponCreature, Armor armor, TypeOfAttack attackType) : base("Goblin", 120, weaponCreature, armor, positionX, positionY, attackType)
        {
            Direction = Direction.Up;
            IsDead = false;
            CurrentHealth = 120;
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
            hitPoints = 160;
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

        public void setCreatureHPandDamage(EnitityAbs creature, int damageDemod, int hpDemod)
        {
            if (creature.IsDead == false) 
            {
                creature.hitPoints = hpDemod;
                creature.Weapon.Damage = hpDemod;
            }

            Console.WriteLine("Creature is dead");
            
            

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
