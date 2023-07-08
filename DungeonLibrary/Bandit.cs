using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Bandit : Monster
    {
        //Fields
        // No business rules since this is set in Monster.cs
        //Properties
        bool CanDodge { get; set; }

        public Bandit(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool canDodge)
            : base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
        {
            this.CanDodge = canDodge;
        }
        //CTOR
        public Bandit() : base("Bandit", 15, 2, 20, 6, 1, "Check your pockets and don't trust them.")
        {
            CanDodge = false;
        }
    }
}
