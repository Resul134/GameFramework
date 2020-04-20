using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.AbstractClasses
{
    public abstract class EntityAbs : ICreature
    {

        //Template class
        public string Description { get; set; }
        public double hitPoints { get; set; }
        public TypeOfAttack AttackType { get; set; }
        public Weapon Weapon { get; set; }
        public Armor ArmorType { get; set; }
        public ShieldF ShieldF { get; set; }
        public Direction Direction { get; set; }


        public int FixedPositionX { get; set; }
        public int FixedPositionY { get; set; }

        public bool IsDead { get; set; }

        private double _currentHealth { get; set; }


        public double CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (value <= 0) IsDead = true;
                _currentHealth = value;
            }
        }


        public EntityAbs(string desctription, double hitpoints, Weapon weapon, Armor armor, int fixedPositionX, int fixedPositionY, TypeOfAttack attackType)
        {
            CurrentHealth =  hitPoints;
            hitPoints = hitpoints;
            Description = desctription;
            Weapon = weapon;
            AttackType = attackType;
            ArmorType = armor;

            FixedPositionX = fixedPositionX;
            FixedPositionY = fixedPositionY;

            
            

        }

        public EntityAbs()
        {
        }

        //Template method for classes deriving from this class. Template pattern ensures that the algorithm pattern doesn't get changed,
        //making the structure of the software more managable.
        //Abstract class => concrete class.
        public void WhatIsMyCreatureDamage(double dmg)
        {
             dmg = Weapon.Damage;

             Console.WriteLine($"{dmg}");
        }

      
    }

    
}
