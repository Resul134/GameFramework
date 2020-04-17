using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.States;

namespace LibMandatory.AbstractClasses
{
    public abstract class WeaponAbs : IWeapon
    {

        public TypeOfAttack TypeOfAttack { get; set; }
        public double Damage { get; set; }
        public string WeaponDescription { get; set; }
        public int FixedPositionX { get; set; }
        public int FixedPositionY { get; set; }
    }
}
