using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.States;

namespace LibMandatory.Interfaces
{
    public interface IWeapon
    {
        TypeOfAttack TypeOfAttack { get; set; }
        double Damage { get; set; }
        string WeaponDescription { get; set; }
        int FixedPositionX { get; set; }
        int FixedPositionY { get; set; }
    }
}
