using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    public class PointsWell
    {
        public ushort MaxPoints{ get; protected set; }
        public ushort CurrentPoints { get; protected set; }

        public PointsWell(ushort amount)
        {
            MaxPoints = amount;
            CurrentPoints = amount;
        }

        public void ReducePoints(ushort amount)
        {
            if (amount > CurrentPoints)
                CurrentPoints = 0;
            else
                CurrentPoints -= amount;
        }

        public void IncreasePoints(ushort amount)
        {
            if (CurrentPoints + amount > MaxPoints)
                CurrentPoints = MaxPoints;
            else
                CurrentPoints += amount;
        }

        public void IncreaseMaxPoints(ushort amount)
        {
            MaxPoints += amount;
        }

    }
}

