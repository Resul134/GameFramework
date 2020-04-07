using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.States;

namespace LibMandatory.Items
{
    public class Armor : IGameObject
    {
        public int fixedPositionX { get; set; }
        public int fixedPositionY { get; set; }


        public ArmorType TypeOfArmor { get; set; }
        public string ArmorName { get; set; }
        public double Defense { get; set; }
        public TypeOfAttack attackType { get; set; }




        public Armor(ArmorType armor, string armorname, double defense)
        {
            TypeOfArmor = armor;
            ArmorName = armorname;
            Defense = defense;
            attackType = (TypeOfAttack) adjustResistances(armor);

            
        }




        public double adjustResistances(ArmorType type)
        {
            if (type == ArmorType.Plate)
            {
                if (attackType == TypeOfAttack.Magic)
                {
                    return Defense -=  20;
                }

                if (attackType == TypeOfAttack.Melee)
                {
                    return Defense += 30;
                }
                if (attackType == TypeOfAttack.Ranged)
                {
                    return Defense += 50;
                }


            }
            if (type == ArmorType.Leather)
            {
                if (attackType == TypeOfAttack.Magic)
                {
                    return Defense += 10;
                }

                if (attackType == TypeOfAttack.Melee)
                {
                    return Defense -= 30;
                }
                if (attackType == TypeOfAttack.Ranged)
                {
                    return Defense += 30;
                }
            }
            if(type == ArmorType.Cloth)
            {
                if (attackType == TypeOfAttack.Magic)
                {
                    return Defense += 10;
                }

                if (attackType == TypeOfAttack.Melee)
                {
                    return Defense -= 40;
                }
                if (attackType == TypeOfAttack.Ranged)
                {
                    return Defense += 10;
                }
            }

            return Defense;
        }
  
    }
}
