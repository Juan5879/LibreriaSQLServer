using CRUD.models;
using Microsoft.EntityFrameworkCore;

namespace CRUD;
public class BookStoreContext : DbContext
{
    public DbSet<Autores> Autores { get; set; }
    public DbSet<Libros> Libros { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }
}