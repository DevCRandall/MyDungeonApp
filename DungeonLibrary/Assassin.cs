using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Assassin : Monster
    {
        //Fields
        // No business rules since this is set in Monster.cs
        //Properties
        bool CanDodge { get; set; }

        public Assassin(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool canDodge)
            : base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
        {
            this.CanDodge = canDodge;
        }
        //CTOR
        public Assassin() : base("Assassin", 50, 20, 20, 6, 1, "Very Sneaky")
        {
            CanDodge = false;
        }
        //Method

        //public override int CalcBlock()
        //{

        //Player player1 = new Player(Name, Race.Fairy, EquippedWeapon);
        //int block = HitChance + EquippedWeapon.BonusHitChance;
        //return Dodge;
        //}
        //Full dodge is in a calcBlock override

    }

}
