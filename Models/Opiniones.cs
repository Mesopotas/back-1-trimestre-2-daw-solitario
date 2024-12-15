using System;
using System.Globalization;

public class Opiniones
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Comentario { get; set; }
    public DateTime Fecha { get; set; }
    public int Puntuacion { get; set; }


    public Opiniones(int id, string nombre, string comentario, int puntuacion)
    {
        Id = id;
        Nombre = nombre;
        Comentario = comentario;
        Fecha = DateTime.Now;
        Puntuacion = puntuacion;
    }
}