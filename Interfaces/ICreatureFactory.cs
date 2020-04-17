using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Items;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Interfaces
{
    interface ICreatureFactory
    {
        ICreature makeCreature(int positionX, int positionY, Weapon weapon, Armor armor, TypeOfAttack attackType, double hp, string name);
    }
}
