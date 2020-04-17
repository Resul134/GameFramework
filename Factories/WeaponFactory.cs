using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon GenerateWeapon(TypeOfAttack attackType, double damage, string description, int positinX, int positionY)
        {
            Weapon weapon = new Weapon(attackType, damage, description, positinX, positionY);
            return weapon;
        }


        
    }
}
