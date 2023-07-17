using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //FIELDS - Funny
        private int _minDamage;

        //PROPS - People
        public int MaxDamage { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = (value > 0 && value < MaxDamage) ? value : 1; }
        }

            public string Description { get; set; }



        //CTORs - Collect

        public Monster (string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description)
            : base(name, maxLife, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }

        //METHODS - Monkeys
        public Monster()
        {
            //added so we can create "default: monster subtypes
            //Name = "Baby Goblin"
            //HitChance = 15
            //Goblin babyGoblin = new Goblin()
        }

        public override int CalcDamage()
        {
            // throw new NotImplementedException();
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

        public override string ToString()
        {
            return $"*********** MONSTER ***********\n" +
                    $"{base.ToString()}\n" +
                    $"Damage: {MinDamage} - {MaxDamage}\n" +
                    $"Description: {Description}";
        }

        public static Monster GetMonster()
        {
            //TODO Come back to replace these monsters with your own monster subtypes later.
            Assassin m1 = new("Assassin", 50, 4, 25, 8, 2, "This is an Assassin", false);
            Bandit m2 = new("Bandit", 50, 6, 30, 8, 2, "This is a Bandit", false);
            Berserker m3 = new("Berserker", 50, 9, 35, 8, 2, "This is a Berserker", false);
            Dragon m4 = new("Dragon", 50, 11, 45, 8, 2, "This is a Dragon", false);

            List<Monster> monsters = new()
            {
                m1, m1,
                m2, m2, m2, m2,
                m3, m3, m3,
                m4,
            };

            Random rand = new Random();
            int index = rand.Next(monsters.Count);
            Monster monster = monsters[index];
            return monster;
            //return monsters[new Random().Next(monsters.Count)];
        }

    }
}
