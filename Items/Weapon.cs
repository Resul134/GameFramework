using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Items
{
    public class Weapon
    {
        private Dictionary<TypeOfAttack, Armor> _attackResDic;
        public Weapon(TypeOfAttack typeOfAttack, double damage, string weaponDescription)
        {
            TypeOfAttack = typeOfAttack;
            Damage = damage;
            WeaponDescription = weaponDescription;
            _attackResDic = new Dictionary<TypeOfAttack, Armor>();
        }



        #region Properties

        public TypeOfAttack TypeOfAttack { get; set; }
        public double Damage { get; set; }
        public string WeaponDescription { get; set; }
        


        #endregion

        public double CheckWeaponResistanceToArmor(TypeOfAttack attackStyle, ArmorType armorType)
        {
            if (armorType == ArmorType.Plate)
            {
                //Defense against magic with Plate, LINQ
                if (attackStyle == TypeOfAttack.Magic)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Plate) );
                    
                }
                //Defense against ranged with Plate, LINQ
                if (attackStyle == TypeOfAttack.Ranged)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Plate));

                }
                //Defense against Mellee with Plate, LINQ
                if (attackStyle == TypeOfAttack.Ranged)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Plate));

                }
            }

            if (armorType == ArmorType.Cloth)
            {
                //Defense against magic with Cloth, LINQ
                if (attackStyle == TypeOfAttack.Magic)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Cloth));

                }
                //Defense against ranged with Cloth, LINQ
                if (attackStyle == TypeOfAttack.Ranged)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Cloth));

                }
                //Defense against Mellee with Cloth, LINQ
                if (attackStyle == TypeOfAttack.Ranged)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Cloth));

                }
            }


            if (armorType == ArmorType.Leather)
            {
                //Defense against magic with Leather, LINQ
                if (attackStyle == TypeOfAttack.Magic)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Leather));

                }
                //Defense against ranged with Leather, LINQ
                if (attackStyle == TypeOfAttack.Ranged)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Leather));

                }
                //Defense against Mellee with Cloth, LINQ
                if (attackStyle == TypeOfAttack.Melee)
                {
                    return _attackResDic.Values.Sum(damageDealth => damageDealth.adjustResistances(ArmorType.Leather));

                }
            }

            return Damage;

        }




       
    }
}
