using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Dragon : Monster
    {
        //Fields
        // No business rules since this is set in Monster.cs
        //Properties
        bool CanDodge { get; set; }

        public Dragon(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool canDodge)
            : base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
        {
            this.CanDodge = canDodge;
        }
        //CTOR
        public Dragon() : base("Dragon", 50, 25, 20, 6, 1, "Fire breathing behemoth")
        {
            CanDodge = false;
        }
    }
}
