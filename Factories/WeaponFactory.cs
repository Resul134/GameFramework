using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Factories
{
    public class WeaponFactory
    {
        public Weapon GenerateWeapon(TypeOfAttack attackType, double damage, string description, int positinX, int positionY)
        {
            Weapon weapon = new Weapon(attackType, damage, description, positinX, positionY);
            return weapon;
        }
    }
}
