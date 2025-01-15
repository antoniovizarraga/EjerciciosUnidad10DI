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
                        oPersona.Foto = (string)lector["Foto"];

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

        /// <summary>
        ///  Elimina una persona en la Base de Datos a través de su ID
        ///  Pre: El id debería ser mayor que 0
        /// </summary>
        /// <param name="id">Identificador de la persona a eliminar en la Base de Datos</param>
        /// <returns>bool seBorra</returns>
        public static bool BorraPersonaDAL(int id)
        {
            bool seBorra = false;

            //Si queremos poner la opción de borrar más de una persona y queremos ver las filas afectadas
            //int numeroFilasAfectadas = 0;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = ClsConexion.GetConexion();

            miComando.Parameters.AddWithValue("@id", id);

            try
            {
                miConexion.Open();

                miComando.CommandText = "DELETE FROM Personas WHERE ID=@id";

                miComando.Connection = miConexion;

                if (miComando.ExecuteNonQuery() > 0)
                {
                    seBorra = true;
                }

                //Si queremos poner la opción de borrar más de una persona y queremos ver las filas afectadas
                //numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return seBorra;

            //Si queremos poner la opción de borrar más de una persona y queremos ver las filas afectadas
            //return numeroFilasAfectadas;
        }


        /// <summary>
        /// Añade una persona en nuestra Base de Datos a traves de una persona pasada por parametros
        /// Pre: Tiene que pasar una persona rellena
        /// </summary>
        /// <param name="persona"> Persona de la clase ClsPersona</param>
        /// <returns>bool seCrea</returns>
        public static bool CreaPersonaDAL(ClsPersona persona)
        {
            bool seCrea = false;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = ClsConexion.GetConexion();

            try
            {
                miConexion.Open();

                miComando.Parameters.AddWithValue("@nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                miComando.Parameters.AddWithValue("@tel", persona.Telefono);
                miComando.Parameters.AddWithValue("@dir", persona.Direccion);
                miComando.Parameters.AddWithValue("@foto", persona.Foto);
                miComando.Parameters.AddWithValue("@fecha", persona.FechaNacimiento);
                miComando.Parameters.AddWithValue("@dep", persona.IDDepartamento);
                miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento,IDDepartamento) " +
                    "VALUES (@nombre, @apellidos, @tel, @dir, @foto, @fecha, @dep)";

                miComando.Connection = miConexion;

                if (miComando.ExecuteNonQuery() > 0)
                {
                    seCrea = true;
                }

            }
            catch (SqlException exSql)
            {

                throw exSql;

            }
            finally
            {
                miConexion.Close();
            }
            return seCrea;

        }

        /// <summary>
        /// Edita una persona de nuestra Base de Datos a traves de una persona pasada por parametros
        /// Pre: Pasa una persona con los datos a cambiar
        /// </summary>
        /// <param name="persona"> Persona de la clase ClsPersona</param>
        /// <returns>bool seEdita</returns>
        public static int EditaPersonaDAL(ClsPersona persona)
        {
            int res;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            miConexion.ConnectionString = ClsConexion.GetConexion();

            try
            {
                miConexion.Open();

                miComando.Parameters.AddWithValue("@id", persona.Id);
                miComando.Parameters.AddWithValue("@nombre", persona.Nombre);
                miComando.Parameters.AddWithValue("@apellidos", persona.Apellidos);
                miComando.Parameters.AddWithValue("@tel", persona.Telefono);
                miComando.Parameters.AddWithValue("@dir", persona.Direccion);
                miComando.Parameters.AddWithValue("@foto", persona.Foto);
                miComando.Parameters.AddWithValue("@fecha", persona.FechaNacimiento);
                miComando.Parameters.AddWithValue("@dep", persona.IDDepartamento);
                miComando.CommandText = "UPDATE Personas SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @tel, Foto = @foto, FechaNacimiento = @fecha, Direccion = @dir, idDepartamento = @dep WHERE Id = @id";

                miComando.Connection = miConexion;

                res = miComando.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {

                throw exSql;

            }
            finally
            {
                miConexion.Close();
            }
            return res;

        }

        public static ClsPersona personaSeleccionada(int id)
        {
            ClsPersona persona = new ClsPersona();

            SqlConnection miConexion = new SqlConnection();


            miConexion.ConnectionString = ClsConexion.GetConexion();

            string query = "SELECT * FROM personas WHERE ID = @id";

            using (SqlCommand micomando = new SqlCommand(query, miConexion)) { 
                micomando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                try
                {
                    miConexion.Open();

                    using (SqlDataReader miLector = micomando.ExecuteReader())
                    {
                        if(miLector.Read())
                        {
                            persona = new ClsPersona
                            {
                                Id = (int)miLector["ID"],
                                Nombre = (string)miLector["Nombre"],
                                Apellidos = (string)miLector["Apellidos"],
                                Telefono = (string)miLector["Telefono"],
                                Direccion = (string)miLector["Direccion"],
                                FechaNacimiento = (DateTime)miLector["FechaNacimiento"],
                                Foto = (string)miLector["Foto"],
                                IDDepartamento = (int)miLector["IDDepartamento"],

                        };
                        }
                    }
                } catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return persona;
        }
            
    }
}
