using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    public abstract class Hp
    {
        public ushort MaxHp { get; protected set; }
        public ushort CurrentHp { get; protected set; }
        public bool IsAlive => CurrentHp != 0;

        public Hp(ushort amount)
        {
            MaxHp = amount;
            CurrentHp = amount;
        }

        public void ReceiveDamage(ushort damage)
        {
            if (damage > CurrentHp)
                CurrentHp = 0;
            else
                CurrentHp -= damage;
        }

        public void Heal(ushort amount)
        {
            if (CurrentHp + amount > MaxHp)
                CurrentHp = MaxHp;
            else
                CurrentHp += amount;
        }

        public abstract void OnDeath();
        public abstract void IncreaseStatsOnLevelUp();

    }
}

