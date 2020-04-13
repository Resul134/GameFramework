﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.AbstractClasses
{
    public abstract class CreatureAbs : IGameObject
    {

 
        public string Description { get; set; }
        public double hitPoints { get; set; }
        public TypeOfAttack AttackType { get; set; }
        public Weapon Weapon { get; set; }
        public Armor ArmorType { get; set; }
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


        public CreatureAbs(string desctription, double hitpoints, Weapon weapon, Armor armor, int fixedPositionX, int fixedPositionY, TypeOfAttack attackType)
        {
            CurrentHealth =  hitPoints;
            hitPoints = hitpoints;
            Description = desctription;
            Weapon = weapon;
            AttackType = attackType;
            ArmorType = armor;

            FixedPositionX = fixedPositionX;
            FixedPositionY = fixedPositionY;

            IsDead = false;


        }

      
    }

    
}
