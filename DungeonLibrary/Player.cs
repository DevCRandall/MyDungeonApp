using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //FIELDS - Funny

        //PROPS - People
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }

        //CTORs - Collect

        public Player(string name,/*int hitChance, int block, int maxLife,*/ Race playerRace, Weapon equippedWeapon) :
            base(name, 70, 5, 40)//hitchance, block, maxLife/Life - These are the base values and will change with player class.
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            #region Race Bonus
            switch (playerRace)
            {
                case Race.Human:
                    HitChance += 5;
                    break;
                case Race.Dragonborn:
                    HitChance += 2;
                    Life += 5;
                    MaxLife += 5;
                    break;
                case Race.Fairy:
                    HitChance += 7;
                    Life -= 2;
                    MaxLife -= 2;
                    break;
                case Race.Dwarf:
                    HitChance += 3;
                    Life += 3;
                    MaxLife -= 3;
                    break;
                case Race.Barbarian:
                    HitChance += 4;
                    Life -= 4;
                    MaxLife -= 4;
                    break;
                case Race.Druid:
                    HitChance += 5;
                    Life += 5;
                    MaxLife -= 5;
                    break;
                default:
                    break;
            }

            #endregion
        }

        //METHODS - Monkeys

        private static string GetRaceDesc(Race race)
        {
            switch (race)
            {
                case Race.Human:
                    return "Human";
                case Race.Dragonborn:
                    return "Dragonborn";
                case Race.Fairy:
                    return "Fairy";
                case Race.Dwarf:
                    return "Dwarf";
                case Race.Barbarian:
                    return "Barbarian";
                case Race.Druid:
                    return "Druid";
                default:
                    return "";
            }
        }//end getRaceDesc ()

        public override string ToString()
        {
            return base.ToString() + $"\nWeapon: \n{EquippedWeapon}\n" +
                $"Description: \n{GetRaceDesc(PlayerRace)}";
        }
        //CalcDamage() override -> return a random number between the EquippedWeapon's MinDamage and MaxDamage properties.
        public override int CalcDamage()
        {
            //throw new NotImplementedException();
            Random rand = new Random();
            //.Next() 0 to int.MaxValue
            //.Next(int value) 0 to value - 1
            //.Next(int value1, int value2) value1 to value2 - 1
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            //Upper bound is exclusive, so we add 1 to the max damage.
            return damage;
        }
        //CalcHitChance() override -> return the HitChance + EquippedWeapon's BonusHitChance property.
        public override int CalcHitChance()
        {
            int chance = HitChance + EquippedWeapon.BonusHitChance;
            return chance;
        }

    }
}
