using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;

namespace LibMandatory.Models
{
    public class Spikes : IGameObject
    {
        public int FixedPositionX { get; set; }
        public int FixedPositionY { get; set; }
        public string Descrtiption { get; set; }
        public double Damage { get; set; }


        public Spikes(int fixedPositionX, int fixedPositionY, string descrtiption)
        {
            FixedPositionX = fixedPositionX;
            FixedPositionY = fixedPositionY;
            Descrtiption = descrtiption;
            Damage = 20;
        }


        public override string ToString()
        {
            return $"{nameof(FixedPositionX)}: {FixedPositionX}, {nameof(FixedPositionY)}: {FixedPositionY}, {nameof(Descrtiption)}: {Descrtiption}";
        }
    }
}
