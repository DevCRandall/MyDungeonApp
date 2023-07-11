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

        public WeaponType Type { get; set; }

        //CTORs - Collect
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, int bonusDamage, WeaponType type)
        {
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"Weapon Type: {Type}";
        }

        //METHODS - Monkeys
    }
}
