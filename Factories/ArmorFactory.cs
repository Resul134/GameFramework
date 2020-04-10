using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Factories
{
    public class ArmorFactory
    {
        public Armor getTypeOfArmor(ArmorType armorType, string armorname, double defense, int positionX, int positionY)
        {
            Armor createArmor = new Armor(armorType, armorname, defense, positionX, positionY);
            return createArmor;
        }


        
    }
}
