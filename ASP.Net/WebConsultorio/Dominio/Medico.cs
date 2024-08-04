using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico
    {
        public long Id { get; set; }
        public Especialidad Especialidad { get; set;}
        public Persona Datos_personales { get; set;}
        public DateTime Fecha_ingreso { get; set;}
        public decimal Costo_consulta { get; set;}
        public List<string> Imagenes { get; set; }
    }
}
