using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LibMandatory.AbstractClasses;
using LibMandatory.Interfaces;
using LibMandatory.Models;
using LibMandatory.States;

namespace LibMandatory.Items
{
    public class Weapon : WeaponAbs
    {
        private Dictionary<TypeOfAttack, Armor> _attackResDic;
        public Weapon(TypeOfAttack typeOfAttack, double damage, string weaponDescription, int positionX, int positionY)
        {
            TypeOfAttack = typeOfAttack;
            Damage = CantMakeLowDmgWeapon(damage);
            WeaponDescription = weaponDescription;
            _attackResDic = new Dictionary<TypeOfAttack, Armor>();
            FixedPositionY = positionY;
            FixedPositionX = positionX;

        }

        public Weapon()
        {
            
        }



        #region Properties

        



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


        //Eksperimental method
        public Weapon RandomizeWeaponByAttackStyle(TypeOfAttack attackType)
        {
            Weapon weapon = new Weapon();
            Random rand = new Random();

            if (attackType == TypeOfAttack.Magic)
            {
                weapon.Damage = rand.Next(30, 60);
                weapon.WeaponDescription = "Random Wand";
                weapon.TypeOfAttack = TypeOfAttack.Magic;
                return weapon;

            }
            if (attackType == TypeOfAttack.Melee)
            {
                weapon.Damage = rand.Next(30, 60);
                weapon.WeaponDescription = "Random Sword";
                weapon.TypeOfAttack = TypeOfAttack.Melee;
                return weapon;
            }
            if (attackType == TypeOfAttack.Ranged)
            {
                weapon.Damage = rand.Next(30, 60);
                weapon.WeaponDescription = "Random Bow";
                weapon.TypeOfAttack = TypeOfAttack.Ranged;
                return weapon;
            }

            return weapon;

        }

        private double CantMakeLowDmgWeapon(double dmg)
        {
           

            if (dmg < 20)
            {
                throw new ArgumentException("Damage cannot be lower than 20");
            }


            return dmg;


        }


        public override string ToString()
        {
            return $"{nameof(TypeOfAttack)}: {TypeOfAttack}, {nameof(Damage)}: {Damage}, {nameof(WeaponDescription)}: {WeaponDescription}";
        }


       
    }
}
