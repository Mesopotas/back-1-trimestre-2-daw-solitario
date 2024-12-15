using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

[ApiController]
[Route("MinimalCinema/[controller]")]
public class OpinionesController : ControllerBase
{
    private static List<Opiniones> opiniones = new List<Opiniones>();

    public OpinionesController()
    {
        if (opiniones.Count == 0)
        {
            InicializarOpiniones();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<object>> GetAllOpiniones()
    {
        var opinionesFormateadas = opiniones.Select(o => new
        {
            o.Id,
            o.Nombre,
            o.Comentario,
            Fecha = o.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
            o.Puntuacion
        });

        return Ok(opinionesFormateadas);
    }

    [HttpGet("{id}")]
    public ActionResult<object> GetOpinionesById(int id)
    {
        var opinion = opiniones.FirstOrDefault(a => a.Id == id);
        if (opinion == null)
        {
            return NotFound($"Opinión con ID {id} no encontrada.");
        }

        var opinionFormateada = new
        {
            opinion.Id,
            opinion.Nombre,
            opinion.Comentario,
            Fecha = opinion.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
            opinion.Puntuacion
        };

        return Ok(opinionFormateada);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var opinion = opiniones.FirstOrDefault(b => b.Id == id);
        if (opinion == null)
        {
            return NotFound($"Opinión con ID {id} no encontrada.");
        }

        opiniones.Remove(opinion);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult ActualizarComentario(int id, [FromBody] string comentario)
    {
        var opinion = opiniones.FirstOrDefault(b => b.Id == id);
        if (opinion == null)
        {
            return NotFound($"Opinión con ID {id} no encontrada.");
        }

        opinion.Comentario = comentario;
        return NoContent();
    }

    [HttpPost]
    public ActionResult CrearOpinion([FromBody] Opiniones nuevaOpinion)
    {
        nuevaOpinion.Id = opiniones.Count > 0 ? opiniones.Max(s => s.Id) + 1 : 1;
        nuevaOpinion.Fecha = DateTime.Now;
        opiniones.Add(nuevaOpinion);
        return Ok(nuevaOpinion);
    }

    private static void InicializarOpiniones()
    {
        opiniones.Add(new Opiniones(1, "Nicolas", "Comentario de Nicolás", 1));
        opiniones.Add(new Opiniones(2, "Nicolas2", "Comentario de Nicolás2", 2));
        opiniones.Add(new Opiniones(3, "Nicolas3", "Comentario de Nicolás3", 3));
        opiniones.Add(new Opiniones(4, "Nicolas4", "Comentario de Nicolás4", 4));
        opiniones.Add(new Opiniones(5, "Nicolas5", "Comentario de Nicolás5", 5));
    }

    public static List<Opiniones> GetOpiniones()
    {
        return opiniones;
    }
}
