namespace CRUD.models
{
    public class Clientes
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
