using System;

public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;
    private int cantidad;

    public ListaEnlazada()
    {
        cabeza = null;
        cantidad = 0;
    }

    // Método para agregar un elemento al final de la lista
    public void Agregar(T data)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(data);
        
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        cantidad++;
    }

    // Método para obtener el tamaño de la lista
    public int ObtenerTamano()
    {
        return cantidad;
    }

    // Método para obtener un elemento en una posición específica
    public T ObtenerEn(int indice)
    {
        if (indice < 0 || indice >= cantidad)
        {
            throw new IndexOutOfRangeException("Índice fuera de los límites de la lista.");
        }

        Nodo<T> actual = cabeza;
        for (int i = 0; i < indice; i++)
        {
            actual = actual.Siguiente;
        }
        
        return actual.Data;
    }
    
    // Método para limpiar la lista (útil para la opción de limpiar memoria del menú)
    public void Limpiar()
    {
        cabeza = null;
        cantidad = 0;
    }
}