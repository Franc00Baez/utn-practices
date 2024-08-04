using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    public class StatBlock
    {
        public byte Strength { get; protected set; }
        public byte Intellect { get; protected set; }
        public byte Agility { get; protected set; }


        public StatBlock(Hp character)
        {
            Strength = 1;
            Intellect = 1;
            Agility = 1;
        }
        public StatBlock(byte strength, byte intellect, byte agility)
        {
            if (strength > 100 || intellect > 100 || agility > 100)
                throw new ArgumentOutOfRangeException("Los valores deben estar en el rango de 0 a 100");

            Strength = strength;
            Intellect = intellect;
            Agility = agility;
        }
        public void IncreaseStats(byte strength, byte intellect, byte agility)
        {
            Strength += strength;
            Intellect += intellect;
            Agility += agility;
        }
        public override string ToString()
        {
            return "Strength: " + Strength + "\n" + "Intelect: " + Intellect + "\n" + "Agility: " + Agility;
        }

    }
}
