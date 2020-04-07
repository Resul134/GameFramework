using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Factories;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class World
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public IGameObject[,] Environment { get; set; }
        private HumanPlayer player { get; set; }
        


        public World(IGameObject[,] environment)
        {

            Environment = environment;
            Height = environment.GetLength(0);
            Width = environment.GetLength(1);
           
        }

        public IGameObject[,] makeMap(int height, int width)
        {
            return MakeMap(height, width);
        }

        private static IGameObject[,] MakeMap(int height, int width)
        {
            IGameObject[,] map = new IGameObject[height, width];


            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    map[i, j] = new Board(i, j, "Stormwind");
                }
            }

            return map;
        }


        public void PrintMap(List<Creatures> Creatures)
        {
            var printMap = GameObjects(Creatures);

            MapHandler(printMap);
        }

        private void MapHandler(IGameObject[,] printMap)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    switch (printMap[y, x])
                    {
                        case Board board:
                            Console.Write('B');
                            break;
                        case Creatures creature:
                            Console.Write('C');
                            break;
                        case HumanPlayer player:
                            Console.Write('P');
                            break;
                        case Weapon weapon:
                            Console.Write('W');
                            break;
                        case Armor armour:
                            Console.Write('A');
                            break;
                    }
                }

                Console.WriteLine();
            }
        }

        private IGameObject[,] GameObjects(List<Creatures> Creatures)
        {
            Console.Clear();
            IGameObject[,] printMap = (IGameObject[,]) Environment.Clone();
            Creatures.ForEach(monster => printMap[monster.FixedPositionY, monster.FixedPositionY] = monster);
            return printMap;
        }
    }









}

