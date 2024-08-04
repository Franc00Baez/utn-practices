using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    public class Wizzard : Hp
    {
        public string Name { get; private set; }
        public StatBlock Stats { get; protected set; }

        public const ushort HPGROWTH = 12;
        public const byte STRBASE = 1;
        public const byte INTBASE = 5;
        public const byte AGLBASE = 1;

        public Wizzard(string name) : base(HPGROWTH)
        {
            Name = name;
            Stats = new StatBlock(STRBASE, INTBASE, AGLBASE);
        }
        public override void IncreaseStatsOnLevelUp()
        {
            Stats.IncreaseStats(STRBASE, INTBASE, AGLBASE);
            MaxHp += HPGROWTH;
            CurrentHp = MaxHp;
        }
        public override void OnDeath()
        {
            throw new NotImplementedException();
        }
    }
}
