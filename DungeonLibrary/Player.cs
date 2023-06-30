using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //FIELDS - Funny        //PROPS - People        public Race PlayerRace { get; set; }        public Weapon EquippedWeapon { get; set; }        public int Score { get; set; }        //CTORs - Collect        public Player(string name,/*int hitChance, int block, int maxLife,*/ Race playerRace, Weapon equippedWeapon) :            base(name, 70, 5,40)//hitchance, block, maxLife/Life - These are the base values and will change with player class.        {            PlayerRace = playerRace;            EquippedWeapon = equippedWeapon;

            #region Race Bonus            switch(playerRace)
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
            }

            #endregion        }        //METHODS - Monkeys
    }
}
