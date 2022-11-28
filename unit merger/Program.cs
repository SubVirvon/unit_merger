using System;
using System.Linq;

namespace unit_merger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior[] platoon1 = new Warrior[] 
            {
                new Warrior("Глеб"),
                new Warrior("Борис"),
                new Warrior("Михаил"),
                new Warrior("Богдан"),
                new Warrior("Константин"),
                new Warrior("Евгений"),
            };
            Warrior[] platoon2 = new Warrior[]
            {
                new Warrior("Елисей"),
                new Warrior("Алексей"),
                new Warrior("Максим"),
                new Warrior("Александр"),
            };
            Controller controller = new Controller(platoon1, platoon2);

            controller.MergePlatoons("Б");
            controller.ShowPlatoon2();

            Console.ReadKey();
        }
    }

    class Controller
    {
        private Warrior[] _platoon1;
        private Warrior[] _platoon2;

        public Controller(Warrior[] platoon1, Warrior[] platoon2)
        {
            _platoon1 = platoon1;
            _platoon2 = platoon2;
        }

        public void MergePlatoons(string FirstSymbol)
        {
            _platoon2 = _platoon2.Union(_platoon1.Where(warrior => warrior.Name.StartsWith(FirstSymbol))).ToArray();
        }

        public void ShowPlatoon2()
        {
            foreach(var warrior in _platoon2)
            {
                Console.WriteLine(warrior.Name);
            }
        }
    }

    class Warrior
    {
        public string Name { get; private set; }

        public Warrior(string name)
        {
            Name = name;
        }
    }
}
