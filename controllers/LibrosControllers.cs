using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CRUD.models;
using CRUD;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;
using System;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly BookStoreContext _dbcontext;

    public LibrosController(BookStoreContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    [HttpGet]
    public async Task<IResult> GetLibrosAsync()
    {
        return Results.Ok(_dbcontext.Libros.OrderBy(p => p.AutorID).ToList());
    }

    [HttpPost]
    public async Task<IResult> PostLibroAsync([FromBody] Libros libro)
    {
        libro.ID = Guid.NewGuid();
        await _dbcontext.AddAsync(libro);
        await _dbcontext.SaveChangesAsync();

        return Results.Ok(_dbcontext.Libros);
    }

    [HttpPut("{guid}")]
    public async Task<IResult> PutLibroAsync(Guid guid, [FromBody] Libros libro)
    {
        var currentTask = _dbcontext.Libros.Find(guid);

        if (currentTask != null)
        {
            currentTask.AutorID = libro.AutorID;
            currentTask.Titulo = libro.Titulo;
            currentTask.AñoPublicacion = libro.AñoPublicacion;
            currentTask.Genero = libro.Genero;
            currentTask.ISBN = libro.ISBN;
            currentTask.Precio = libro.Precio;
            currentTask.StockDisponible = libro.StockDisponible;

            await _dbcontext.SaveChangesAsync();

            return Results.Ok();
        }
        return Results.NotFound();
    }

    [HttpDelete("{guid}")]
    public async Task<IResult> DeleteLibroAsync(Guid guid)
    {
        var currentTask = _dbcontext.Libros.Find(guid);

        if (currentTask != null)
        {
            _dbcontext.Remove(currentTask);
            await _dbcontext.SaveChangesAsync();

            return Results.Ok();
        }

        return Results.NotFound();
    }
}