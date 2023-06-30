﻿namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS - Funny
        {
            Name = name;
            MaxLife = maxLife;
            Life = maxLife;
            HitChance = hitChance;
            Block = block;
        }
        public Character()
        {

        }

        public virtual int CalcBlock() { return Block; }
        public virtual int CalcHitChance() {  return HitChance; }
        public abstract int CalcDamage();
        public override string ToString()
        {
            return string.Format
                ($"----{Name}----\n" +
                $"Life: {Life} / {MaxLife}\n" +
                $"Hit Chance: {HitChance}\n" +
                $"Block: {Block}");
            
        }
    }
}