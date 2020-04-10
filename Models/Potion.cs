using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;

namespace LibMandatory.Models
{
    public class Potion : IGameObject
    {
        public string Description { get; set; }
        public int FixedPositionX { get; set; }
        public int FixedPositionY { get; set; }


        public Potion(string description, int fixedPositionX, int fixedPositionY)
        {
            Description = description;
            FixedPositionX = fixedPositionX;
            FixedPositionY = fixedPositionY;
        }
    }
}
