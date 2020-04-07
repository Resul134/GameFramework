using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Factories
{
    public class ArmorFactory
    {
        public Armor getTypeOfArmor(ArmorType armorType, string armorname, double defense)
        {
            Armor createArmor = new Armor(armorType, armorname, defense);
            return createArmor;
        }

     
    }
}
