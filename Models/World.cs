using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.AbstractClasses;
using LibMandatory.Factories;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class World : WorldAbs
    {
       





        public World(int width = 20, int height = 20)
        {
           
            heigthY = height;
            widthX = width;
            PlayerHuman = new HumanPlayer("Arthur", 120, new Weapon(TypeOfAttack.Melee, 50, "sword")
                , new Armor(ArmorType.Plate, "Plate", 40), 1, 1, TypeOfAttack.Melee);
            Creatures = new List<CreatureAbs>();
            Weapons = new List<Weapon>();
            Armors = new List<Armor>();


        }


        public void PrintMap()
        {
            
            char[,] map = new char[widthX, heigthY];


           
            for (int h = 0; h < map.GetLength(1); h++)
            {
                for (int w = 0; w < map.GetLength(0); w++)
                {

                    if (PlayerHuman.FixedPositionX == h && PlayerHuman.FixedPositionY == w)
                    {
                        Console.Write(map[w, h] + "b");
                    }

               

                }
                Console.WriteLine();
            }
        }








    }
}
