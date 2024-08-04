using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EspNegocio
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.SetearQuerySP("EspecialidadesListar");
                datos.ejectuarLectura();

                while(datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = (int)datos.Lector["IDESPECIALIDAD"];
                    aux.tipo = (string)datos.Lector["NOMBRE"];
                    lista.Add(aux);
                }
                return lista;
            }catch (Exception ex)
            {
                throw new Exception("Error en la db " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
