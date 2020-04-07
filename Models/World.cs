using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.Items;

namespace LibMandatory.Models
{
    public class World
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public HumanPlayer Player { get; set; }
        public List<Armor> armors { get; set; }
        public List<Weapon> weapons { get; set; }



        public World(IGameObject[,] board)
        {
            Height = board.GetLength(0);
            Width = board.GetLength(1);
            Player = new HumanPlayer()
            weapons = new List<Weapon>();
            armors = new List<Armor>();

        }



    }
}
