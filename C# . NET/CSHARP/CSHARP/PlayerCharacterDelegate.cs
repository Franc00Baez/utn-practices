using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    public abstract class PlayerCharacterDelegate : StatBlock
    {
        public uint Level { get;  set; }
        public uint CurrentXP { get;  set; }
        public uint NextLevel { get; set; }
        public PointsWell Hp;

        public PlayerCharacterDelegate() : base(1,1,1)
        {
            Level = 1;
            CurrentXP = 0;
            NextLevel = SetXPToLevelUp(Level);
            Hp = new PointsWell(100);
        }

        public PlayerCharacterDelegate( byte strength, byte intellect, byte agility, ushort hp) : base(strength, intellect, agility)
        {
            Level = 1;
            CurrentXP = 0;
            NextLevel = SetXPToLevelUp(Level);
            Hp = new PointsWell(hp);
        }

        public uint SetXPToLevelUp(uint level)
        {
            return 100  * level;
        }

        public void GainXP(uint amount)
        {
            CurrentXP += amount;
            while(check_if_leveled())
            {}
        }

        protected bool check_if_leveled()
        {
            if(CurrentXP >= NextLevel)
            {
                Level++;
                LeveUp();
                NextLevel = SetXPToLevelUp(Level);
                return true;
            }
            return false;
        }

        public abstract void LeveUp();
        public abstract string getClassName();
    }
}
