using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Interfaces
{
    public interface ICreature
    {
        string Description { get; set; }
        double hitPoints { get; set; }
        TypeOfAttack AttackType { get; set; }
        Weapon Weapon { get; set; }
        Armor ArmorType { get; set; }
        Direction Direction { get; set; }


        int FixedPositionX { get; set; }
        int FixedPositionY { get; set; }

        bool IsDead { get; set; }

        double CurrentHealth { get; set; }

    }
}
