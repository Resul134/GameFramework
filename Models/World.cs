using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;

namespace LibMandatory.Models
{
    public class World
    {
        public int Height { get; set; }
        public int Width { get; set; }



        public World(IGameObject[,] board)
        {
            Height = board.GetLength(0);
            Width = board.GetLength(1);
        }
    }
}
