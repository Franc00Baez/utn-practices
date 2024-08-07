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
            Warrior war = new Warrior("Lancelote");

            for(int i = 0; i <= 5; i ++)
            {
                Console.WriteLine(war.Name + " - " + war.getClassName());
                Console.WriteLine("MaxHp: " + war.Hp.MaxPoints);
                Console.WriteLine("CurrentHp: " + war.Hp.CurrentPoints);
                Console.WriteLine("Level: " + war.Level);
                Console.WriteLine(war.StatsString());
                Console.WriteLine("CurrentXP: " + war.CurrentXP);
                Console.WriteLine("NextLevel: " + war.NextLevel);
                war.GainXP(100);
                Console.ReadKey();
                Console.WriteLine();
            }

        }
    }
}
