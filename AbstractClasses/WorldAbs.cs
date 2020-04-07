using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Factories;
using LibMandatory.Items;
using LibMandatory.Models;

namespace LibMandatory.AbstractClasses
{
    public abstract class WorldAbs
    {
        public int widthX { get; set; }
        public int heigthY { get; set; }
        public HumanPlayer PlayerHuman { get; set; }
        public List<CreatureAbs> Creatures { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }

        

        
    }
}
