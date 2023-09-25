using CRUD;
using CRUD.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<BookStoreContext>("Data Source=(localdb)\\MSSQLLocalDB;Initial catalog=LibreriaCRUD;Trusted_Connection=True; Integrated Security=True");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LibrosController>();
builder.Services.AddScoped<AutoresController>();
builder.Services.AddScoped<ClientesController>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
