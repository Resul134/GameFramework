using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.Interfaces;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Items
{
    public class Weapon : IGameObject
    {
        private Dictionary<TypeOfAttack, Armor> _attackResDic;
        public Weapon(TypeOfAttack typeOfAttack, double damage, string weaponDescription, int positionX, int positionY)
        {
            TypeOfAttack = typeOfAttack;
            Damage = damage;
            WeaponDescription = weaponDescription;
            _attackResDic = new Dictionary<TypeOfAttack, Armor>();
            FixedPositionY = positionY;
            FixedPositionX = positionX;
        }

        public Weapon()
        {
            
        }



        #region Properties

        public TypeOfAttack TypeOfAttack { get; set; }
        public double Damage { get; set; }
        public string WeaponDescription { get; set; }
        public int FixedPositionX { get; set; }
        public int FixedPositionY { get; set; }



        #endregion

        public double CheckDamagetoToArmorType(TypeOfAttack attackStyle, ArmorType armorType)
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


        public override string ToString()
        {
            return $"{nameof(TypeOfAttack)}: {TypeOfAttack}, {nameof(Damage)}: {Damage}, {nameof(WeaponDescription)}: {WeaponDescription}";
        }

        
    }
}
