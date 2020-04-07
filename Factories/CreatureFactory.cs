using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Items;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Factories
{
    public class CreatureFactory
    {
        public Creatures makeCreature(int positionX, int positionY, Weapon weapon, Armor armor, TypeOfAttack attackType )
        {
            Creatures creature =  new Creatures(positionX, positionY, weapon, armor, attackType);
            return creature;
        }

        
    }
}
