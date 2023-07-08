namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS - Funny

        //PROPS - People
        public string Name { get; set; }

        public int MaxLife { get; set; }

        public int Life { get; set; }

        public int HitChance { get; set; }

        public int Block { get; set; }

        
        //CTORs - Collect
        public Character (string name, int maxLife, int hitChance, int block, int life)
        {
            Name = name;
            MaxLife = maxLife;
            Life = maxLife;
            HitChance = hitChance;
            Block = block;
            Life = life;
        }
        public Character(string name, int maxLife, int hitChance, int block)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
        }

        //METHODS - Monkeys
        public Character () 
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