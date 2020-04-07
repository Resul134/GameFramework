using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMandatory.Interfaces
{
    public interface IGameObject
    {
        string Description { get; set; }
        int FixedPositionX { get; set; }
        int FixedPositionY { get; set; }

    }
}
