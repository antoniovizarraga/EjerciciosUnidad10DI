namespace CapaDAL
{
    public class ClsPersona
    {
        #region Atributos
        private int id;
        private String nombre;
        private String apellidos;
        private String fechaNacimiento;
        private String foto;
        private String direccion;
        private long telefono;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
        }

        public int Nombre
        {
            get { return id; }
            set { id = value; }
        }

        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public long Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        #endregion

        #region Constructores
        public ClsPersona()
        {

        }

        public ClsPersona(int id, String nombre, String apellidos, String fechaNacimiento, String foto, String direccion, long telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.foto = foto;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        #endregion
    }
}
