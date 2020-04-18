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


        //Testing if i can move the methods to it's class
        public void SpikesEncountered(World player)
        {
            if (player != null)
            {
                foreach (var s in player.SpikeList)
                {
                    if (player.Player.FixedPositionX == FixedPositionX && player.Player.FixedPositionY == s.FixedPositionY)
                    {
                        player.Player.CurrentHealth -= Damage;
                    }
                }
            }
        }


        public override string ToString()
        {
            return $"{nameof(Descrtiption)}: {Descrtiption}";
        }
    }
}
