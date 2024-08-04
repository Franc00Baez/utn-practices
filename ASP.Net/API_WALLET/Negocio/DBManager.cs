using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using Helpers;

namespace Negocio
{
    public class DBManager
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private Log exLog = new Log();

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public DBManager()
        {
            try
            {
                conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DB_EASYBOX;" + "Integrated Security=True");
                comando = new SqlCommand();

            }catch (Exception ex)
            {
                exLog.Add(ex.Message);
            }
        }
        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setearSP(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void setearParametroSalida(string nombre, SqlDbType tipo)
        {
            comando.Parameters.Add(new SqlParameter(nombre, tipo) { Direction = ParameterDirection.Output });
        }
        public object obtenerParametroSalida(string nombre)
        {
            return comando.Parameters[nombre].Value;
        }
        public void ejecturarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }catch (Exception ex)
            {
                exLog.Add(ex.Message);
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                exLog.Add(ex.Message);
            }
        }
        public int ejecutarScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                exLog.Add(ex.Message);
                return -1;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
