namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS - Funny
        private int _maxLife;
        private int _life;
        //PROPS - People
        public string Name { get; set; }

        public int MaxLife 
        {
            get { return _maxLife; }
            set { _maxLife = value; } 
        }

        public int Life
        {
            get { return _life; }
            //Life cannot be more than MaxLife (think healing). If it is, just set it to the value of MaxLife.
            set { _life = value <= MaxLife ? value : MaxLife; } //always reference other properties, not fields, in case there are business rules in place.
        }

        public int HitChance { get; set; }

        public int Block { get; set; }

        
        //CTORs - Collect
        public Character (string name, int maxLife, int hitChance, int block, int life)
        {
            Name = name;
            MaxLife = maxLife;
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
            Life = maxLife;
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