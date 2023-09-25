namespace CRUD.models
{
    public class Libros
    {
        public Guid ID { get; set; }
        public Guid AutorID { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AñoPublicacion { get; set;}
        public string ISBN { get; set; }
        public decimal Precio { get; set; }
        public int StockDisponible { get; set; }
    }
}
