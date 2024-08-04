using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Helpers;
using Negocio;

namespace Negocio
{
    public class UsuarioManager
    {
        protected Log exLog = new Log();
        
        public bool UsuarioExiste(string nombreUsuario)
        {
            DBManager datos = new DBManager();
            bool existe = false;
            string query = @"SELECT CASE 
            WHEN EXISTS (SELECT 1 FROM USUARIOS WHERE nombre = @nombreUsuario)
            THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
            END AS UsuarioExiste";
             
            try
            {
                datos.setearQuery(query);
                datos.setearParametro("@nombreUsuario", nombreUsuario);
                datos.ejecturarLectura();

                if (datos.Lector.Read()) // Lee el primer registro
                {
                    existe = datos.Lector.GetBoolean(0); // Lee el primer campo del registro
                }

            }
            catch (Exception ex)
            {
                exLog.Add("UsuarioExiste: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return existe;
        }
        public bool  EmailExiste(string email)
        {
            bool existe = false;
            DBManager datos = new DBManager();
            string query = @"
                SELECT CASE 
                    WHEN EXISTS (SELECT 1 FROM USUARIOS WHERE email = @Email)
                    THEN CAST(1 AS BIT)
                    ELSE CAST(0 AS BIT)
                END AS EmailExiste";

            try
            {
                datos.setearQuery(query);
                datos.setearParametro("@Email", email);
                datos.ejecturarLectura();

                if (datos.Lector.Read()) // Lee el primer registro
                {
                    existe = datos.Lector.GetBoolean(0); // Lee el primer campo del registro
                }

            }
            catch (Exception ex)
            {
                exLog.Add("EmailExiste: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return existe;
        }

        public bool RegistrarNuevo(Usuario usuario)
        {
            bool seRegistro = false;
            DBManager datos = new DBManager();
            string query = @"INSERT INTO USUARIOS (nombre, email, hashpass, img_root, id_rol, activo, creacion)
                VALUES (@nombre, @correo, @hashpass, @imgRoot, @idRol, @activo, @creacion)";
            
            try
            {
                datos.setearQuery(query);
                datos.setearParametro("@nombre", usuario.nombre);
                datos.setearParametro("@correo", usuario.email);
                datos.setearParametro("@hashpass", usuario.pass_hash);
                datos.setearParametro("@imgRoot", usuario.img_perfil != null ? usuario.img_perfil : (object)DBNull.Value);
                datos.setearParametro("@idRol", 1);
                datos.setearParametro("@activo", true);
                datos.setearParametro("@creacion", DateTime.Now);

                datos.ejecutarAccion();
                seRegistro = true;

            }catch (Exception ex)
            {
                exLog.Add("RegistrarUsuario" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return seRegistro;
        }

        public int ObtenerIdPorUsuario(string input)
        {
            DBManager datos = new DBManager();
            int id = -1;

            try
            {
                datos.setearSP("sp_UsernameOrEmail");
                datos.setearParametro("@input", input);
                datos.ejecturarLectura();

                if(datos.Lector.Read())
                {
                    id = datos.Lector.GetInt32(0);
                }

            }catch (Exception ex)
            {
                exLog.Add("Obtener id por usuario: " + ex.Message);
            }finally
            {
                datos.cerrarConexion();
            }

            return id;
        }

        public bool PasswordCheck(int id, string password)
        {
            DBManager datos = new DBManager();
            string hashpass;
            bool bandera = false;
            string query = @"SELECT hashpass
                             FROM USUARIOS
                             WHERE id = @id;";

            try
            {
                datos.setearQuery(query);
                datos.setearParametro("@id", id);
                datos.ejecturarLectura();

                if(datos.Lector.Read())
                {
                    hashpass = datos.Lector["hashpass"].ToString();
                    bandera = HashService.VerifyPassword(password, hashpass);
                }


            }catch (Exception ex)
            {
                exLog.Add("PasswordCheck: " + ex.Message);
                return false;
            }finally
            {
                datos.cerrarConexion();
            }

            return bandera;
        }

        public Usuario ObenerUsuario(int id)
        {
            DBManager datos = new DBManager();
            Usuario user = new Usuario();

            try
            {
                datos.setearSP("sp_GetUserForLogin");
                datos.setearParametro("@id", id);
                datos.ejecturarLectura();

                if(datos.Lector.Read())
                {
                    user.id = (int)datos.Lector["id"];
                    user.nombre = (string)datos.Lector["nombre"];
                    user.email = (string)datos.Lector["email"];
                    user.pass_hash = (string)datos.Lector["hashpass"];
                    user.img_perfil = datos.Lector["img_root"] != DBNull.Value ? (string)datos.Lector["img_root"] : null;
                    user.rol = (Role)datos.Lector["id_rol"];
                    user.activo = (bool)datos.Lector["activo"];
                    user.fecha_creacion = (DateTime)datos.Lector["creacion"];
                }
            }catch (Exception ex)
            {
                exLog.Add("ObtenerUsuario: " + ex.Message);
                return user;
            }finally
            {
                datos.cerrarConexion();

            }
            return user;
        }
    }
}
