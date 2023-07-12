using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Weapon
    {
        //FIELDS - Funny

        private int _minDamage;

        //PROPS - People
        public string Name { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            //Min damage must be greater than 0 and less than Max. If not, default to 1.
            set { _minDamage = value > 0 && value < MaxDamage ? value : 1; }
        }
        public int MaxDamage { get; set; }
        public int BonusHitChance { get; set; }
        public int BonusDamage { get; set; }
        public WeaponType Type { get; set; }

        //CTORs - Collect
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, int bonusDamage, WeaponType type)
            
        {
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            BonusDamage = bonusDamage;
            BonusHitChance = bonusHitChance;
            Type = type;


            #region Weapon Bonus
            switch (type)
            {
                case WeaponType.Club:
                    MinDamage += 5;
                    MaxDamage += 0;
                    BonusDamage += 0;
                    BonusHitChance += 5;
                    break;
                case WeaponType.BattleAxe:
                    MinDamage += 5;
                    MaxDamage += 0;
                    BonusDamage += 0;
                    BonusHitChance += 0;
                    break;
                case WeaponType.Longsword:
                    MinDamage += 5;
                    MaxDamage += 0;
                    BonusDamage += 0;
                    BonusHitChance += 0;
                    break;
                case WeaponType.Longbow:
                    MinDamage += 5;
                    MaxDamage += 0;
                    BonusDamage += 0;
                    BonusHitChance += 0;
                    break;
                case WeaponType.Trident:
                    MinDamage += 5;
                    MaxDamage += 0;
                    BonusDamage += 0;
                    BonusHitChance += 0;
                    break;
                default:
                    break;
            }
            #endregion Weapon Bonus
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"Weapon Type: {Type}";
        }

        //METHODS - Monkeys
        public static string GetWeaponDesc(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Club:
                    return "Club:\n" +
                        "minDamage += 5;\n" +
                    "MaxDamage += 0;\n" +
                    "BonusHitChance += 0\n\n";
                case WeaponType.BattleAxe:
                    return "BattleAxe:\n" +
                        "minDamage += 5;\n" +
                    "MaxDamage += 0;\n" +
                    "BonusHitChance += 0\n\n";
                case WeaponType.Longsword:
                    return "Longsword:\n" +
                        "minDamage += 5;\n" +
                    "MaxDamage += 0;\n" +
                    "BonusHitChance += 0\n\n";
                case WeaponType.Longbow:
                    return "Longbow:\n" +
                        "minDamage += 5;\n" +
                    "MaxDamage += 0;\n" +
                    "BonusHitChance += 0\n\n";
                case WeaponType.Trident:
                    return "Trident:\n" +
                        "minDamage += 5;\n" +
                    "MaxDamage += 0;\n" +
                    "BonusHitChance += 0\n\n";
                default:
                    return "";
            }
        }
    }
}
