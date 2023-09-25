using CRUD.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly BookStoreContext _dbcontext;

    public AutoresController(BookStoreContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    [HttpGet]
    public async Task<IResult> GetAutorAsync()
    {
        return Results.Ok(_dbcontext.Autores);
    }

    [HttpPost]
    public async Task<IResult> PostAutorAsync([FromBody] Autores autor)
    {
        autor.ID = Guid.NewGuid();
        await _dbcontext.AddAsync(autor);
        await _dbcontext.SaveChangesAsync();

        return Results.Ok(_dbcontext.Autores);
    }

    [HttpPut("{guid}")]
    public async Task<IResult> PutAutorAsync(Guid guid, [FromBody] Autores autor)
    {
        var currentTask = _dbcontext.Autores.Find(guid);

        if (currentTask != null)
        {
            currentTask.Nombre = autor.Nombre;
            currentTask.Apellido = autor.Apellido;
            currentTask.FechaNacimiento = autor.FechaNacimiento;
            currentTask.Pais = autor.Pais;
            currentTask.Biografia = autor.Biografia;

            await _dbcontext.SaveChangesAsync();

            return Results.Ok();
        }
        return Results.NotFound();

    }

    [HttpDelete("{guid}")]
    public async Task<IResult> DeleteAutorAsync(Guid guid)
    {
        var currentTask = _dbcontext.Autores.Find(guid);

        if (currentTask != null)
        {
            _dbcontext.Remove(currentTask);
            await _dbcontext.SaveChangesAsync();

            return Results.Ok();
        }

        return Results.NotFound();

    }
}


