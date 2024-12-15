namespace Models;

public class Peliculas
{

    public int Id_Pelicula { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Actores { get; set; }
    public string Directores { get; set; }
    public double Duracion { get; set; }
    public double Precio { get; set; }
    public int Edad_Recomendada { get; set; }
    public string Caratula { get; set; }
    public int Id_Categoria { get; set; }
    public string Nombre_Categoria { get; set; }
    public List<Opiniones> Opiniones {get; set;}


    public Peliculas(int id_pelicula, string nombre, string descripcion, string actores, string directores, double duracion, double precio, int edad_recomendada, string caratula, int id_categoria, string nombre_categoria, List<Opiniones> opiniones)
    {

        Id_Pelicula = id_pelicula;
        Nombre = nombre;
        Descripcion = descripcion;
        Actores = actores;
        Directores = directores;
        Duracion = duracion;
        Precio = precio;
        Edad_Recomendada = edad_recomendada;
        Caratula = caratula;
        Id_Categoria = id_categoria;
        Nombre_Categoria = nombre_categoria;
        Opiniones = opiniones;

    }
}
