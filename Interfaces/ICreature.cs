using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMandatory.Interfaces
{
    interface ICreature
    {
        string Description { get; set; }
        double hitPoints { get; set; }
            
    }
}
