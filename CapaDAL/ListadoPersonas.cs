using CapaENT;
using Microsoft.Data.SqlClient;

namespace CapaDAL
{
    public class ListadoPersonas
    {
        /// <summary>
        /// Crea una lista de Personas y se conecta a la BDD para devolvela llena
        /// </summary>
        /// <returns> List<ClsPersona> </returns>
        public static List<ClsPersona> ListaPersonas()
        {

            List<ClsPersona> listado = new List<ClsPersona>()
            {
                new ClsPersona("Paco","Jiménez Ortiz","987654321","Calle Inventada","Lmfao.jpg",DateTime.Parse("10/03/2005"),1),
                new ClsPersona("María", "Gómez Fernández", "654987321", "Avenida Falsa 123", "maria.jpg", DateTime.Parse("05/06/1995"), 2),
                new ClsPersona("Luis", "Pérez López", "123456789", "Calle de los Sueños", "luis.png", DateTime.Parse("15/02/1987"), 3),
                new ClsPersona("Ana", "Martínez García", "789456123", "Plaza del Sol", "ana.jpg", DateTime.Parse("20/11/2000"), 4),
                new ClsPersona("Carlos", "Hernández Ruiz", "321654987", "Camino Viejo", "carlos.jpeg", DateTime.Parse("01/01/1990"), 5),
                new ClsPersona("Lucía", "Sánchez Díaz", "456123789", "Calle Nueva", "lucia.jpg", DateTime.Parse("25/08/1993"), 6),
                new ClsPersona("Javier", "Rodríguez Moreno", "963852741", "Boulevard Principal", "javier.jpg", DateTime.Parse("30/12/1985"), 7),
                new ClsPersona("Sara", "López Jiménez", "741258963", "Carretera Central", "sara.jpg", DateTime.Parse("12/07/1999"), 8),
                new ClsPersona("David", "García Torres", "852369741", "Callejón Oscuro", "david.jpg", DateTime.Parse("05/04/2003"), 9),
                new ClsPersona("Elena", "Ortiz Navarro", "147258369", "Ruta de las Flores", "elena.jpg", DateTime.Parse("19/09/1998"), 10)

            };

            return listado;

            /* 

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

                miConexion.Close();

            }

            catch (SqlException ex)

            {

                throw ex;

            }

            return listadoPersonas; */

        }

        public static ClsPersona BuscarPersonaPorId(int id) {

            ClsPersona persona = ListaPersonas().FirstOrDefault(p => p.Id == id);

            if(persona == null)
            {
                persona = new ClsPersona("Desconocido","Desconocido","Desconocido","Desconocido","temp.jpg",DateTime.Now,0);
            }

            return persona;
        }

        public static void AddPersona(String nombre, String apellidos, String telefono, String direccion, String foto, DateTime fechaNac) { 

            int id = ListaPersonas().Max(p => p.Id) + 1;

            ClsPersona persona = new ClsPersona(nombre, apellidos, telefono, direccion, foto, fechaNac, id);

            ListaPersonas().Add(persona);

        }

        public static void EliminarPersona(int id) {

            ClsPersona persona = BuscarPersonaPorId(id);

            ListaPersonas().Remove(persona);
        }

        public static void ActualizarPersona(int idPersonaQueActualizar, String nombre, String apellidos, String telefono, String direccion, String foto, DateTime fechaNac)
        {
            ClsPersona persona = BuscarPersonaPorId(idPersonaQueActualizar);
            

            if (persona != null) {
                int id = persona.Id;
                persona.Nombre = nombre;
                persona.Apellidos = apellidos;
                persona.Telefono = telefono;
                persona.Direccion = direccion;
                persona.Foto = foto;
                persona.FechaNacimiento = fechaNac;

                EliminarPersona(id);
                AddPersona(persona.Nombre, persona.Apellidos, persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento);
            }

        }
    }
}
