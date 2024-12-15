public class Sala
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Capacidad { get; set; }
    public List<Asiento> Asientos { get; set; }

    public Sala(int id, string nombre, int capacidad, List<Asiento> asientos)
    {
        Id = id;
        Nombre = nombre;
        Capacidad = capacidad;
        Asientos = asientos;
    }
}