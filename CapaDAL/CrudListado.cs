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
            ClsPersona persona = new ClsPersona();

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

            }
            finally
            {
                miConexion.Close();
            }

            return persona;
        }
    }
}
