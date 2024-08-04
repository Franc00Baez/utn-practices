using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MedicosNegocio
    {
        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDB Datos = new AccesoDB();

            try
            {
                Datos.SetearQuerySP("MedicosListar");
                Datos.ejectuarLectura();

                while(Datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("IDMEDICO")) ? 0 : Datos.Lector.GetInt64(Datos.Lector.GetOrdinal("IDMEDICO"));
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("IDESPECIALIDAD")) ? 0 : Datos.Lector.GetInt32(Datos.Lector.GetOrdinal("IDESPECIALIDAD"));
                    aux.Especialidad.tipo = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("ESPECIALIDAD")) ? string.Empty : Datos.Lector.GetString(Datos.Lector.GetOrdinal("ESPECIALIDAD"));
                    aux.Datos_personales = new Persona();
                    aux.Datos_personales.Nombre = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("NOMBRE")) ? string.Empty : Datos.Lector.GetString(Datos.Lector.GetOrdinal("NOMBRE"));
                    aux.Datos_personales.Apellido = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("APELLIDO")) ? string.Empty : Datos.Lector.GetString(Datos.Lector.GetOrdinal("APELLIDO"));
                    aux.Datos_personales.Nacimiento = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("FECHANAC")) ? DateTime.MinValue : Datos.Lector.GetDateTime(Datos.Lector.GetOrdinal("FECHANAC"));
                    aux.Datos_personales.Sexo = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("SEXO")) ? '\0' : Convert.ToChar(Datos.Lector["SEXO"]);
                    aux.Fecha_ingreso = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("FECHAINGRESO")) ? DateTime.MinValue : Datos.Lector.GetDateTime(Datos.Lector.GetOrdinal("FECHAINGRESO"));
                    aux.Costo_consulta = Datos.Lector.IsDBNull(Datos.Lector.GetOrdinal("COSTO_CONSULTA")) ? 0m : Datos.Lector.GetDecimal(Datos.Lector.GetOrdinal("COSTO_CONSULTA"));
                    aux.Imagenes = ObtenerImagenes(aux.Id);
                    lista.Add(aux);
                }
                return lista;
            }catch (Exception ex)
            {
                throw new Exception("Hay un error en la BD" + ex.Message);
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        public List<string> ObtenerImagenes(long MedicoId)
        {
            List<string> lista = new List<string>();
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearQuery("Select IMAGEN as Img from IMAGENES where IDMEDICO = @MedicoID;");
                Datos.setearParametro("@MedicoID", MedicoId);
                Datos.ejectuarLectura();

                while(Datos.Lector.Read())
                {
                    string url = (string)Datos.Lector["Img"];
                    lista.Add(url);
                }
                return lista;
            } catch (Exception ex)
            {
                throw new Exception("Hubo un error en la db " + ex.Message);
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        public void Agregar(Medico medico)
        {
            AccesoDB Datos = new AccesoDB();
            try
            {
                Datos.SetearQuery("INSERT INTO MEDICOS (IDMEDICO,IDESPECIALIDAD, APELLIDO, NOMBRE, SEXO, FECHANAC, FECHAINGRESO, COSTO_CONSULTA) VALUES (@IdMedico, @IdEspecialidad, @Apellido, @Nombre, @Sexo, @Fechanac, @Fechaingreso, @Costo_consulta); Insert Into IMAGENES(IDMEDICO,IMAGEN) Values (@IdMedico, @UrlImagen)");
                Datos.setearParametro("@IdMedico", medico.Id);
                Datos.setearParametro("@IdEspecialidad", medico.Especialidad.Id);
                Datos.setearParametro("@Apellido", medico.Datos_personales.Apellido);
                Datos.setearParametro("@Nombre", medico.Datos_personales.Nombre);
                Datos.setearParametro("@Sexo", medico.Datos_personales.Sexo);
                Datos.setearParametro("@Fechanac", medico.Datos_personales.Nacimiento);
                Datos.setearParametro("@Fechaingreso", medico.Fecha_ingreso);
                Datos.setearParametro("@Costo_consulta", medico.Costo_consulta);
                Datos.setearParametro("@UrlImagen", medico.Imagenes[0]);
                Datos.ejecutarAccion();


            }catch (Exception ex)
            {
                throw new Exception("Error en BD" + ex.Message);
            }finally
            {
                Datos.cerrarConexion();
            }
        }
    }
}
