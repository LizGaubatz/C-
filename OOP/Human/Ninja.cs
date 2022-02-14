namespace Human
{
    class Ninja : Human
    {
        public Ninja(string name, int strength, int intelligence) : base(name, strength, intelligence, 175, 1000)
        {
        }
        public override int Attack(Human target)
        {
            int damage = 5 * Dexterity;
            target.Health -= damage;
            return target.Health;
        }

        public void Steal(Human target){
            target.Health -= 5;
            Health += 5;
        }
    }
}