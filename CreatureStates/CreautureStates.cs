using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.Items;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.CreatureStates
{
    public class CreautureStates
    {
        
        public ICreature SPawnDemon(int positionX, int positionY)
        {
            #region making objects for Demon

            Weapon weapon = new Weapon(TypeOfAttack.Demonic, 300, "Demon", positionX, positionY);
            Armor arm = new Armor(ArmorType.Demonic, "Demonic plate", 200, positionX, positionY);

            #endregion

            ICreature creat = new Entities(positionX, positionY, weapon, arm, TypeOfAttack.Demonic, 400, "Demon");

                
                return creat;

        }

        //Experiment
        public void If_Creature_Name_Resul(ICreature Entity)
        {
            if (Entity.Description == "Resul")
            {
                Entity.CurrentHealth = 30;
                Entity.ArmorType.Defense = 10;
            }
            throw new ArgumentException("Entity was not named Resul");
        }

       
    }
}
