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
    public abstract class CreatureAbs : IGameObject
    {

 
        public string Description { get; set; }
        public double hitPoints { get; set; }
        public TypeOfAttack AttackType { get; set; }
        public Weapon Weapon { get; set; }
        public Armor ArmorType { get; set; }
        public LivingState StateOfLife { get; set; }


        public int FixedPositionX { get; set; }
        public int FixedPositionY { get; set; }

        public bool IsDead
        {
            get => hitPoints <= 0;
            set => throw new NotImplementedException();
        }


        public CreatureAbs(string desctription, double hitpoints, Weapon weapon, Armor armor, int fixedPositionX, int fixedPositionY, TypeOfAttack attackType)
        {
            hitPoints = hitpoints;
            Description = desctription;
            Weapon = weapon;
            AttackType = attackType;
            ArmorType = armor;

            FixedPositionX = fixedPositionX;
            FixedPositionY = fixedPositionY;


        }

      
    }

    
}
