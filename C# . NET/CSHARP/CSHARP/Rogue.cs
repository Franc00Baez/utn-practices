using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    class Rogue : PlayerCharacterDelegate
    {
        public string Name { get; private set; }

        public const ushort HPGROWTH = 14;

        public const byte STRBASE = 2;
        public const byte INTBASE = 1;
        public const byte AGLBASE = 4;

        public Rogue(string name) : base(STRBASE, INTBASE, AGLBASE, HPGROWTH)
        {
            Name = name;
        }

        public override void LeveUp()
        {
            ushort hp = HPGROWTH / 2;
            byte str = STRBASE / 2;
            byte inte = INTBASE / 2;
            byte agl = AGLBASE / 2;

            Hp.IncreaseMaxPoints(hp);
            Hp.IncreasePoints(Hp.MaxPoints);
            IncreaseStats(str, inte, agl);
        }

        public override string getClassName()
        {
            return "Warrior";
        }
    }
}
