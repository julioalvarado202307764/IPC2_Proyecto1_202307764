public class Celda
{
    public int Fila { get; set; }
    public int Columna { get; set; }
    
    // 0 = sana, 1 = contagiada 
    public int EstadoActual { get; set; } 
    public int EstadoSiguiente { get; set; }

    public Celda(int fila, int columna, int estadoInicial)
    {
        Fila = fila;
        Columna = columna;
        EstadoActual = estadoInicial;
        EstadoSiguiente = 0; // Por defecto inicia sana para el siguiente turno
    }
}