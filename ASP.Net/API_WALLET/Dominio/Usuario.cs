using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum Role
    {
        Admin = 1,
        User = 2
    }
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string img_perfil { get; set; }
        public string email { get; set; }
        public string pass_hash { get; set; }
        public DateTime fecha_creacion { get; set; }
        public bool activo { get; set; }
        public Role rol { get; set; }
    }
}
