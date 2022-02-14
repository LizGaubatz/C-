namespace Human
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        public int Health{
            get {
                return health;
            }
            set {
                health = value;
            }
        }
        public Human(string name){
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        public Human(string name, int strength, int intelligence, int dexterity, int life){
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            health = life;
        }
        public virtual int Attack(Human target){
            int damage = Strength * 3;
            target.health -= damage;
            System.Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage");
            return target.health;
        }

        public void DispayInfo(){
            System.Console.WriteLine($"Name: {Name} Strength: {Strength} Intelligence: {Intelligence} Dexterity: {Dexterity} Health: {health}");
        }
    }
}