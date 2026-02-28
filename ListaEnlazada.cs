using System;

// --- LISTA DE PACIENTES ---
public class ListaPacientes
{
    private NodoPaciente cabeza;
    private int cantidad;

    public ListaPacientes() { cabeza = null; cantidad = 0; }

    public void Agregar(Paciente data)
    {
        NodoPaciente nuevoNodo = new NodoPaciente(data);
        if (cabeza == null) { cabeza = nuevoNodo; }
        else
        {
            NodoPaciente actual = cabeza;
            while (actual.Siguiente != null) { actual = actual.Siguiente; }
            actual.Siguiente = nuevoNodo;
        }
        cantidad++;
    }

    public int ObtenerTamano() { return cantidad; }

    public Paciente ObtenerEn(int indice)
    {
        NodoPaciente actual = cabeza;
        for (int i = 0; i < indice; i++) { actual = actual.Siguiente; }
        return actual.Data;
    }

    public void Limpiar() { cabeza = null; cantidad = 0; }
}

// --- LISTA DE CELDAS ---
public class ListaCeldas
{
    private NodoCelda cabeza;
    private int cantidad;

    public ListaCeldas() { cabeza = null; cantidad = 0; }

    public void Agregar(Celda data)
    {
        NodoCelda nuevoNodo = new NodoCelda(data);
        if (cabeza == null) { cabeza = nuevoNodo; }
        else
        {
            NodoCelda actual = cabeza;
            while (actual.Siguiente != null) { actual = actual.Siguiente; }
            actual.Siguiente = nuevoNodo;
        }
        cantidad++;
    }

    public int ObtenerTamano() { return cantidad; }

    public Celda ObtenerEn(int indice)
    {
        NodoCelda actual = cabeza;
        for (int i = 0; i < indice; i++) { actual = actual.Siguiente; }
        return actual.Data;
    }

    // Método de búsqueda específico sin usar delegados genéricos
    public Celda BuscarPorPosicion(int fila, int columna)
    {
        NodoCelda actual = cabeza;
        while (actual != null)
        {
            if (actual.Data.Fila == fila && actual.Data.Columna == columna)
            {
                return actual.Data;
            }
            actual = actual.Siguiente;
        }
        return null;
    }
}

// --- LISTA DE STRINGS (Para el historial del simulador) ---
public class ListaStrings
{
    private NodoString cabeza;
    private int cantidad;

    public ListaStrings() { cabeza = null; cantidad = 0; }

    public void Agregar(string data)
    {
        NodoString nuevoNodo = new NodoString(data);
        if (cabeza == null) { cabeza = nuevoNodo; }
        else
        {
            NodoString actual = cabeza;
            while (actual.Siguiente != null) { actual = actual.Siguiente; }
            actual.Siguiente = nuevoNodo;
        }
        cantidad++;
    }

    public int ObtenerTamano() { return cantidad; }

    public string ObtenerEn(int indice)
    {
        NodoString actual = cabeza;
        for (int i = 0; i < indice; i++) { actual = actual.Siguiente; }
        return actual.Data;
    }
}