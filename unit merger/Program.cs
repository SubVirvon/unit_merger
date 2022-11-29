using System;
using System.Linq;
using System.Collections.Generic;

namespace unit_merger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Warrior> platoon1 = new List<Warrior>()
            {
                new Warrior("Глеб"),
                new Warrior("Борис"),
                new Warrior("Михаил"),
                new Warrior("Богдан"),
                new Warrior("Константин"),
                new Warrior("Евгений"),
            };
            List<Warrior> platoon2 = new List<Warrior>()
            {
                new Warrior("Елисей"),
                new Warrior("Алексей"),
                new Warrior("Максим"),
                new Warrior("Александр"),
            };
            Controller controller = new Controller(platoon1, platoon2);

            controller.MergePlatoons("Б");

            controller.ShowPlatoon1();
            controller.ShowPlatoon2();

            Console.ReadKey();
        }
    }

    class Controller
    {
        private List<Warrior> _platoon1;
        private List<Warrior> _platoon2;

        public Controller(List<Warrior> platoon1, List<Warrior> platoon2)
        {
            _platoon1 = platoon1;
            _platoon2 = platoon2;
        }

        public void MergePlatoons(string FirstSymbol)
        {
            List<Warrior> necessaryWarriors = _platoon1.Where(warrior => warrior.Name.StartsWith(FirstSymbol)).ToList();

            foreach (var warrior in necessaryWarriors)
            {
                _platoon1.Remove(warrior);
            }

            _platoon2 = _platoon2.Union(necessaryWarriors).ToList();
        }

        public void ShowPlatoon1()
        {
            Console.WriteLine("Взвод 1:");

            ShowPlatoon(_platoon1);
        }

        public void ShowPlatoon2()
        {
            Console.WriteLine("Взвод 2:");

            ShowPlatoon(_platoon2);
        }

        private void ShowPlatoon(List<Warrior> platoon)
        {
            foreach (var warrior in platoon)
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
