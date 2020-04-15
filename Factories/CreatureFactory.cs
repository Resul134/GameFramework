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
        public Enitities makeCreature(int positionX, int positionY, Weapon weapon, Armor armor, TypeOfAttack attackType, double hp, string name )
        {
            Enitities enitity =  new Enitities(positionX, positionY, weapon, armor, attackType, hp, name);
            return enitity;
        }

        


    }
}
