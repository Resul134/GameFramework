using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Factories;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.States;

namespace LibMandatory.Models
{
    public class Board : IGameObject
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Name { get; set; }
        private List<Creatures> creatures;
        private List<Weapon> weapons;
        Random rand = new Random();

        public Board(int positionX, int positionY, string name)
        {
            PositionX = positionX;
            PositionY = PositionY;
            Name = name;


        }


        public void addCreaturesToBoard(Weapon weapon, Armor armor, TypeOfAttack attackType)
        {
            CreatureFactory cf = new CreatureFactory();

            creatures = new List<Creatures>();
            

            for (int i = 0; i < rand.Next(0,7); i++)
            {
                creatures.Add(cf.makeCreature(rand.Next(0,4),rand.Next(0,4), weapon, armor, attackType));
            }
        }

        




    }
}
