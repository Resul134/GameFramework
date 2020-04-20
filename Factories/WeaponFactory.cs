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



        //Decorator factory, if type equals ranged. Simpler way of returning an object, instead of user typing a millin parameters.
        public IWeapon makeBow(TypeOfAttack weaponType)
        {
            
            Random rand = new Random();
            int posY = rand.Next(0, 25);
            int posX = rand.Next(0, 25);
            if (weaponType == TypeOfAttack.Ranged)
            {
                
                return new Weapon(TypeOfAttack.Ranged, 30, "Bow", posX,posY);
            }
            throw new ArgumentException("Weapon type wasn't bow");
        }


        
    }
}
