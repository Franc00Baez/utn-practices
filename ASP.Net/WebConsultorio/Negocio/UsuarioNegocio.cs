using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.SetearQuery("Select Id, TipoUser FROM USUARIOS where usuario = @user and password = @password ");
                datos.setearParametro("@user", usuario.User);
                datos.setearParametro("@password", usuario.Password);

                datos.ejectuarLectura();
                while(datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? UserType.ADMIN : UserType.NORMAL;
                    return true;
                }
                return false;

            }catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
