﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //FIELDS - Funny

            #region Race Bonus
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

            #endregion
    }
}