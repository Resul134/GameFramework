using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.States;

namespace LibMandatory.CreatureStates
{
    public class CreautureStates
    {
        //Experimenting with states
        public ICreature Demon_If_Creature_Name_Demon(ICreature Entity)
        {
            if (Entity.Description == "Demon")
            {
                
                Entity.Weapon.TypeOfAttack = TypeOfAttack.Demonic;
                Entity.ArmorType.TypeOfArmor = ArmorType.Demonic;

                if (Entity.Weapon.TypeOfAttack == TypeOfAttack.Demonic)
                {
                    Entity.Weapon.Damage = 500;
                    Entity.ArmorType.Defense = 400;
                    Entity.CurrentHealth = 300;

                    


                }
            }
            throw new ArgumentException("Entity is not dead");
        }


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
