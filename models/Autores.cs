namespace CRUD.models
{
    public class Autores
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Pais { get; set; }
        public string Biografia { get; set; }
    }
}
