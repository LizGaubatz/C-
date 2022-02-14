namespace Human
{
    class Samurai : Human
    {
        public Samurai(string name, int strength, int intelligence, int dexterity) : base(name, strength, intelligence, dexterity, 2000)
        {
        }

        public override int Attack(Human target)
        {
            base.Attack(target);
            if(target.Health < 50) {
                target.Health = 0;
            }
            return target.Health;
        }

        public void Meditate(){
            Health = 2000;
        }
    }
}