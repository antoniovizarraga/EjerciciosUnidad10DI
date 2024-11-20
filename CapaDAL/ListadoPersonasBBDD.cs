using CapaENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    public class ListadoPersonasBBDD
    {
        public static List<ClsPersona> ListadoDePersonas() {
            SqlConnection miConexion = new SqlConnection();

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand comando = new SqlCommand();

            SqlDataReader lector;

            ClsPersona oPersona;

            miConexion.ConnectionString = ClsConexion.GetConexion();

            try

            {

                miConexion.Open();


                comando.CommandText = "SELECT * FROM Personas";

                comando.Connection = miConexion;

                lector = comando.ExecuteReader();


                if (lector.HasRows)

                {

                    while (lector.Read())

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

                        listadoPersonas.Add(oPersona);

                    }

                }

                lector.Close();

                

            }

            catch (SqlException ex)

            {

                throw ex;

            } finally
            {
                miConexion.Close();
            }

            return listadoPersonas;
        }

            
    }
}
