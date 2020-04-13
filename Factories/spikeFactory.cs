using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Models;

namespace LibMandatory.Factories
{
    public class spikeFactory
    {
        public Spikes makePotions(int positionX, int positionY, string description)
        {
            Spikes spike = new Spikes(positionX, positionY, description);
            return spike;
        }
    }
}
