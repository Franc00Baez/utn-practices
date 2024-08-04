using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string Apellido { get; set;}
        public string Nombre { get; set; }
        public char Sexo { get; set; }
        public DateTime Nacimiento { get; set; }

        public string NombreApellido()
        {
            return Nombre + " " + Apellido;
        }
    }
}
