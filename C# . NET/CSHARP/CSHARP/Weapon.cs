using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP
{
    public abstract class Weapon
    {
        public string Name { get; private set; }
        public ushort Damage { get; private set; }
        public bool Equiped { get; set; }

        public Weapon(string name, ushort damage, bool equiped)
        {
            Name = name;
            Damage = damage;
            Equiped = equiped;
        }

        public void EquipeUnequipe()
        {
            if (Equiped)
                Equiped = false;
            else
                Equiped = true;
        }
    }
}
