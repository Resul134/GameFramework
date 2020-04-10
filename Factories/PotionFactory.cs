using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Items;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Factories
{
    public class PotionFactory
    {
        public Potion makePotions(int positionX, int positionY, string description)
        {
            Potion creature = new Potion(description, positionX, positionY );
            return creature;
        }
    }
}
