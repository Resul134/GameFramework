using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.AbstractClasses;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Factories
{
    public class CreatureFactory : ICreatureFactory
    {
        public ICreature makeCreature(int positionX, int positionY, Weapon weapon, Armor armor, TypeOfAttack attackType, double hp, string name )
        {
            if (hp < 0)
            {
                
                throw new ArgumentException("HP has to above 0");
            }

            ICreature entity =  new Entities(positionX, positionY, weapon, armor, attackType, hp, name);
            return entity;
        }


        
    }
}
