using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Interfaces
{
    public interface IWeaponFactory
    {
        IWeapon GenerateWeapon(TypeOfAttack attackType, double damage, string description, int positinX, int positionY);
    }
}
