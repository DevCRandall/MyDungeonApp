using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //FIELDS - Funny

        //PROPS - People
        public string Name {  get; set; }
        public int MinDamage { get; set; }
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
            BonusHitChance = bonusHitChance;
            BonusDamage = bonusDamage;
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
