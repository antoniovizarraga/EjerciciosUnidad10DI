using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class ClsConexion
    {
        /// <summary>
        /// Devuelve la cadena de conexión
        /// </summary>
        /// <returns>String cadena</returns>
        public static string GetConexion()
        {
            string cadena = "server=avizarraga.database.windows.net;" +
                    "database=AntonioBD;uid=usuario;" +
                    "pwd=LaCampana123; trustServerCertificate=true;";

            return cadena;
        }
    }
}
