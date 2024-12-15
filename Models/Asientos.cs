public class Asiento
{
    public int Numero { get; set; }
    public bool EstaReservado { get; set; }

    public Asiento(int numero, bool estaReservado)
    {
        Numero = numero;
        EstaReservado = estaReservado;
    }
}