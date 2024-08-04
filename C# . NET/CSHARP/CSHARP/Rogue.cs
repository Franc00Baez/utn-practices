using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    class Rogue : Hp
    {
        public string Name { get; private set; }
        public StatBlock Stats { get; protected set; }

        public const ushort HPGROWTH = 15;

        public const byte STRBASE = 2;
        public const byte INTBASE = 1;
        public const byte AGLBASE = 4;

        public const byte STRGROWTH = 1;
        public const byte INTGROWTH = 0;
        public const byte AGLGROWTH = 5;

        public Rogue(string name) : base(HPGROWTH)
        {
            Name = name;
            Stats = new StatBlock(STRBASE, INTBASE, AGLBASE);
        }
        public override void IncreaseStatsOnLevelUp()
        {
            Stats.IncreaseStats(STRGROWTH, INTGROWTH, AGLGROWTH);
            MaxHp += HPGROWTH;
            CurrentHp = MaxHp;
        }
        public override void OnDeath()
        {
            throw new NotImplementedException();
        }
    }
}
