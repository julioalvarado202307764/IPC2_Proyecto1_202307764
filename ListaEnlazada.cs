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
    // Método para buscar un elemento basado en una condición
    public T Buscar(Func<T, bool> condicion)
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            // Si el dato actual cumple la condición, lo devolvemos
            if (condicion(actual.Data))
            {
                return actual.Data;
            }
            actual = actual.Siguiente;
        }

        // Retorna el valor por defecto (null para objetos) si no lo encuentra
        return default(T);
    }
    // Método para eliminar un elemento en una posición específica
    public void EliminarEn(int indice)
    {
        if (indice < 0 || indice >= cantidad)
        {
            throw new IndexOutOfRangeException("Índice fuera de los límites de la lista.");
        }

        // Caso 1: Queremos eliminar el primer elemento (la cabeza)
        if (indice == 0)
        {
            cabeza = cabeza.Siguiente;
        }
        // Caso 2: Queremos eliminar un elemento en el medio o al final
        else
        {
            Nodo<T> actual = cabeza;
            
            // Avanzamos hasta el nodo ANTERIOR al que queremos eliminar
            for (int i = 0; i < indice - 1; i++) 
            {
                actual = actual.Siguiente;
            }
            
            // "Saltamos" el nodo que queremos borrar, enlazando con el siguiente del siguiente
            actual.Siguiente = actual.Siguiente.Siguiente;
        }
        
        cantidad--; // Reducimos el tamaño de la lista
    }
}
