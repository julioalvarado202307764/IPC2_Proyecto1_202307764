// Nodo para los Pacientes
public class NodoPaciente
{
    public Paciente Data { get; set; }
    public NodoPaciente Siguiente { get; set; }

    public NodoPaciente(Paciente data)
    {
        Data = data;
        Siguiente = null;
    }
}

// Nodo para las Celdas (Rejilla)
public class NodoCelda
{
    public Celda Data { get; set; }
    public NodoCelda Siguiente { get; set; }

    public NodoCelda(Celda data)
    {
        Data = data;
        Siguiente = null;
    }
}

// Nodo para el Historial de firmas (Strings)
public class NodoString
{
    public string Data { get; set; }
    public NodoString Siguiente { get; set; }

    public NodoString(string data)
    {
        Data = data;
        Siguiente = null;
    }
}