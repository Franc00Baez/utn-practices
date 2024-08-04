using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior war = new Warrior("Lazaro");
            Rogue rogue = new Rogue("Exequiel");
            LevelSystem obj1 = new LevelSystem(war);
            LevelSystem obj2 = new LevelSystem(rogue);

            for(int i = 1; i <= 3; i++)
            {
                Console.WriteLine("----------------- " + war.Name + " -----------------");
                Console.WriteLine("/ \t" + "Level: " + obj1.Level);
                Console.WriteLine("/ \t" + "CurrentXP: " + obj1.CurrentXP);
                Console.WriteLine("/ \t" + "XPForNextLevel: " + obj1.NextLevel);
                Console.WriteLine("/ \t" + "CurrentHP: " + war.CurrentHp);
                Console.WriteLine("/ \t" + "Strength: " + war.Stats.Strength);
                Console.WriteLine("/ \t" + "Intelect: " + war.Stats.Intellect);
                Console.WriteLine("/ \t" + "Agility: " + war.Stats.Agility);
                Console.WriteLine("\n\n");
                Console.ReadKey();
                obj1.GainXP(150);

                Console.WriteLine("----------------- " + rogue.Name + " -----------------");
                Console.WriteLine("/ \t" + "Level: " + obj2.Level);
                Console.WriteLine("/ \t" + "CurrentXP: " + obj2.CurrentXP);
                Console.WriteLine("/ \t" + "XPForNextLevel: " + obj2.NextLevel);
                Console.WriteLine("/ \t" + "CurrentHP: " + rogue.CurrentHp);
                Console.WriteLine("/ \t" + "Strength: " + rogue.Stats.Strength);
                Console.WriteLine("/ \t" + "Intelect: " + rogue.Stats.Intellect);
                Console.WriteLine("/ \t" + "Agility: " + rogue.Stats.Agility);
                Console.WriteLine("\n\n");
                Console.ReadKey();
                obj2.GainXP(150);
            }

        }
    }
}
