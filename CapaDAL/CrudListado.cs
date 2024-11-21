using CapaENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class CrudListado
    {
        List<ClsPersona> listadoPersonas = new List<ClsPersona>();



        public static ClsPersona BuscarPersonaPorId(int id) { 
            ClsPersona oPersona = new ClsPersona();

            SqlConnection miConexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();

            SqlDataReader lector;

            miConexion.ConnectionString = ClsConexion.GetConexion();

            try

            {

                miConexion.Open();


                comando.CommandText = "SELECT * FROM Personas WHERE ID = " + id.ToString();

                comando.Connection = miConexion;

                lector = comando.ExecuteReader();


                if (lector.HasRows)

                {

                    while (lector.Read() && (int)lector["ID"] != id)

                    {
                        //Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento
                        oPersona = new ClsPersona();

                        oPersona.Id = (int)lector["ID"];

                        oPersona.Nombre = (string)lector["Nombre"];

                        oPersona.Apellidos = (string)lector["Apellidos"];

                        if (lector["FechaNacimiento"] != System.DBNull.Value)

                        { oPersona.FechaNacimiento = (DateTime)lector["FechaNacimiento"]; }

                        oPersona.Direccion = (string)lector["Direccion"];

                        oPersona.Telefono = (string)lector["Telefono"];

                        oPersona.IDDepartamento = (int)lector["IDDepartamento"];

                        

                    }

                }

                lector.Close();



            }

            catch (SqlException ex)

            {

                throw ex;

            }
            finally
            {
                miConexion.Close();
            }

            return oPersona;
        }

        public static void BorrarPersona(int id)
        {
            int filasAfectadas;

            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = ClsConexion.GetConexion();
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                conexion.Open();
                comando.CommandText = "DELETE FROM Personas WHERE ID=@id";
                comando.Connection = conexion;
                filasAfectadas = comando.ExecuteNonQuery();

            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
