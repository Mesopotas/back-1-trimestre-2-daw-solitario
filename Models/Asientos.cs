public class Asientos
{
    public int Numero { get; set; }
    public bool EstaReservado { get; set; }

    public Asientos(int numero, bool estaReservado)
    {
        Numero = numero;
        EstaReservado = estaReservado;
    }
}