using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    public class LevelSystem
    {
        public uint Level { get;  set; }
        public uint CurrentXP { get;  set; }
        public uint NextLevel { get; set; }

        private Hp character;

        public LevelSystem(Hp character)
        {
            this.character = character;
            Level = 1;
            CurrentXP = 0;
            NextLevel = SetXPToLevelUp(Level);
        }

        public uint SetXPToLevelUp(uint level)
        {
            return 100  * level;
        }

        public void GainXP(uint amount)
        {
            CurrentXP += amount;

            while(CurrentXP >= NextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level += 1;
            CurrentXP = CurrentXP - NextLevel;
            NextLevel = SetXPToLevelUp(Level);
            //incremento los stats del personaje 
            character.IncreaseStatsOnLevelUp();
        }
    }
}
