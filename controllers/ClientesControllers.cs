using CRUD.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly BookStoreContext _dbcontext;

    public ClientesController(BookStoreContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    [HttpGet]
    public async Task<IResult> GetClientesAsync()
    {
        return Results.Ok(_dbcontext.Clientes.OrderBy(p => p.Nombre).ToList());
    }

    [HttpPost]
    public async Task<IResult> PostClienteAsync([FromBody] Clientes cliente)
    {
        cliente.ID = Guid.NewGuid();

        await _dbcontext.AddAsync(cliente);
        await _dbcontext.SaveChangesAsync();


        return Results.Ok(_dbcontext.Clientes);
    }

    [HttpPut("{guid}")]
    public async Task<IResult> PutClienteAsync(Guid guid, [FromBody] Clientes cliente)
    {
        var currentTask = _dbcontext.Clientes.Find(guid);

        if (currentTask != null)
        {
            currentTask.Nombre = cliente.Nombre;
            currentTask.Apellido = cliente.Apellido;
            currentTask.FechaNacimiento = cliente.FechaNacimiento;
            currentTask.CorreoElectronico = cliente.CorreoElectronico;
            currentTask.Direccion = cliente.Direccion;
            currentTask.Telefono = cliente.Telefono;

            await _dbcontext.SaveChangesAsync();

            return Results.Ok();
        }
        return Results.NotFound();
    }

    [HttpDelete("{guid}")]
    public async Task<IResult> DeleteClienteAsync(Guid guid)
    {
        var currentTask = _dbcontext.Clientes.Find(guid);

        if (currentTask != null)
        {
            _dbcontext.Remove(currentTask);
            await _dbcontext.SaveChangesAsync();

            return Results.Ok();
        }

        return Results.NotFound();

    }
}