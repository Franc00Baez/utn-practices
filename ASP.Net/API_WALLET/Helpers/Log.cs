using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace Helpers
{
    public class Log
    {
        private string path;

        public Log()
        {
            // Establecer la ruta a la carpeta Logs en el directorio raíz de la aplicación web
            string baseDir = HttpContext.Current.Server.MapPath("~/");
            path = Path.Combine(baseDir, "Logs");
        }

        public void Add(string sLog)
        {
            CrearDirectorio();
            string nombre = GetNombreArchivo();
            string cadena = DateTime.Now + " - " + sLog + Environment.NewLine;

            using (StreamWriter sw = new StreamWriter(Path.Combine(path, nombre), true))
            {
                sw.Write(cadena);
            }
        }

        private string GetNombreArchivo()
        {
            return $"log_{DateTime.Now:yyyy_MM_dd}.txt";
        }

        private void CrearDirectorio()
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
