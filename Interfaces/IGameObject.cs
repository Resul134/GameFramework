using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMandatory.Interfaces
{
    public interface IGameObject
    {
        string nameOfItem { get; set; }
        int fixedPositionX { get; set; }
        int fixedPositionY { get; set; }

    }
}
