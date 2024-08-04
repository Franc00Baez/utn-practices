using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    class AccesoDB
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDB()
        {
            Conexion = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=DIAGNOSTICO;" + "Integrated Security=True");
            Comando = new SqlCommand();
        }

        public void SetearQuery(string consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }

        public void SetearQuerySP(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;
        }
        public void setearParametro(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }
        public void ejectuarLectura()
        {
            Comando.Connection = Conexion;

            try
            {
                Conexion.Open();
                lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            Conexion.Close();
        }

        public int RetornarId()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                return (int)Comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
