using System;

public class Simulador
{
    // 1. Método auxiliar para ver si una celda específica está enferma (1) o sana (0)
    private int ObtenerEstado(ListaCeldas rejilla, int fila, int columna)
    {
        // Usamos nuestro método manual específico, cero genéricos ni lambdas
        Celda celda = rejilla.BuscarPorPosicion(fila, columna);

        if (celda != null)
        {
            return celda.EstadoActual;
        }
        return 0;
    }

    // 2. Método para contar cuántos vecinos contagiados tiene una celda
    private int ContarVecinos(ListaCeldas rejilla, int fila, int columna, int limiteM)
    {
        int vecinos = 0;

        // Las 8 posibles direcciones alrededor de la celda (arriba, abajo, lados y diagonales)
        int[] dFila = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dCol = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int i = 0; i < 8; i++)
        {
            int nFila = fila + dFila[i];
            int nCol = columna + dCol[i];

            // Validamos no salirnos de los límites de la rejilla (de 1 a M)
            if (nFila >= 1 && nFila <= limiteM && nCol >= 1 && nCol <= limiteM)
            {
                vecinos += ObtenerEstado(rejilla, nFila, nCol);
            }
        }
        return vecinos;
    }

    // 3. Método principal para procesar 1 período de tiempo
    public void SimularUnPeriodo(Paciente paciente)
    {
        // Creamos una nueva lista para guardar el estado del siguiente período
        // Así no modificamos la lista actual mientras la estamos evaluando
        ListaCeldas nuevaRejilla = new ListaCeldas();
        // Recorremos toda la matriz M x M
        for (int f = 1; f <= paciente.M; f++)
        {
            for (int c = 1; c <= paciente.M; c++)
            {
                int estadoActual = ObtenerEstado(paciente.Rejilla, f, c);
                int vecinosEnfermos = ContarVecinos(paciente.Rejilla, f, c, paciente.M);
                int estadoSiguiente = 0;

                // Regla 1: Célula contagiada [cite: 21]
                if (estadoActual == 1)
                {
                    if (vecinosEnfermos == 2 || vecinosEnfermos == 3)
                    {
                        estadoSiguiente = 1; // Continúa contagiada [cite: 21]
                    }
                    else
                    {
                        estadoSiguiente = 0; // Sana [cite: 21]
                    }
                }
                // Regla 2: Célula sana [cite: 22]
                else if (estadoActual == 0)
                {
                    if (vecinosEnfermos == 3)
                    {
                        estadoSiguiente = 1; // Se contagia [cite: 22]
                    }
                }

                // Guardamos SOLO las celdas que resultaron contagiadas para el nuevo período
                if (estadoSiguiente == 1)
                {
                    nuevaRejilla.Agregar(new Celda(f, c, 1));
                }
            }
        }

        // Reemplazamos la rejilla vieja por la nueva ya calculada
        paciente.Rejilla = nuevaRejilla;
    }

    // Convierte la lista de celdas en un texto único, ej: "1,1|1,2|2,1|..."
    private string ObtenerFirma(ListaCeldas rejilla)
    {
        string firma = "";
        for (int i = 0; i < rejilla.ObtenerTamano(); i++)
        {
            Celda c = rejilla.ObtenerEn(i);
            firma += $"{c.Fila},{c.Columna}|";
        }
        return firma;
    }

    // Ejecuta los períodos automáticamente hasta encontrar una repetición
    public void AnalizarEnfermedad(Paciente paciente)
    {
        // Historial para guardar las firmas de cada período
        ListaStrings historial = new ListaStrings();

        // Guardamos el patrón inicial en el historial (Período 0)
        historial.Agregar(ObtenerFirma(paciente.Rejilla));
        // Simulamos hasta el máximo de períodos definidos [cite: 104]
        for (int i = 1; i <= paciente.Periodos; i++)
        {
            SimularUnPeriodo(paciente); // Usamos el método que ya teníamos
            string firmaActual = ObtenerFirma(paciente.Rejilla);

            // Buscamos si esta firma ya existe en el historial
            int indiceRepetido = -1;
            for (int j = 0; j < historial.ObtenerTamano(); j++)
            {
                if (historial.ObtenerEn(j) == firmaActual)
                {
                    indiceRepetido = j;
                    break;
                }
            }

            // Si lo encontramos, evaluamos las reglas del proyecto
            if (indiceRepetido != -1)
            {
                if (indiceRepetido == 0)
                {// Caso A: Se repite el patrón inicial [cite: 24]
                    paciente.N = i;
                    paciente.N1 = 0;
                    paciente.Resultado = (paciente.N == 1) ? "mortal" : "grave"; // [cite: 24, 25, 54]
                }
                else
                {// Caso B: Se repite un patrón distinto al inicial [cite: 26, 92]
                    paciente.N = indiceRepetido;
                    paciente.N1 = i - indiceRepetido;
                    paciente.Resultado = (paciente.N1 == 1) ? "mortal" : "grave"; // [cite: 26, 27, 93]
                }

                Console.WriteLine($"\n¡Patrón detectado en el período {i}!");
                Console.WriteLine($"Resultado: {paciente.Resultado}, N: {paciente.N}, N1: {paciente.N1}");
                return; // Cortamos la simulación porque ya tenemos la respuesta
            }

            // Si no se repitió, agregamos la firma al historial y seguimos
            historial.Agregar(firmaActual);
        }

        // Si terminó el ciclo y nunca se repitió nada
        paciente.Resultado = "leve";
        Console.WriteLine($"\nSimulación terminada sin repeticiones.");
        Console.WriteLine($"Resultado: {paciente.Resultado}");
    }
}