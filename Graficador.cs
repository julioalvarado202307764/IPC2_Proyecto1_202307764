using System;
using System.IO;
using System.Diagnostics;

public class Graficador
{
    public void GenerarGrafica(Paciente paciente, string nombreArchivo)
    {
        string rutaDot = nombreArchivo + ".dot";
        string rutaPng = nombreArchivo + ".png";

        try
        {
            // 1. Escribimos el archivo .dot con sintaxis de tabla HTML
            using (StreamWriter writer = new StreamWriter(rutaDot))
            {
                writer.WriteLine("digraph G {");
                writer.WriteLine("  node [shape=plaintext];"); // Quitamos el borde ovalado por defecto
                writer.WriteLine("  rejilla [label=<");
                writer.WriteLine("    <TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\">");

                // Recorremos la matriz M x M del paciente
                for (int f = 1; f <= paciente.M; f++)
                {
                    writer.WriteLine("      <TR>");
                    for (int c = 1; c <= paciente.M; c++)
                    {
                        // Buscamos si la celda está en nuestra lista de contagiadas
                        Celda celda = paciente.Rejilla.BuscarPorPosicion(f, c);
                        
                        // Si existe y su estado es 1, la pintamos. Si no, blanca.
                        string colorFondo = (celda != null && celda.EstadoActual == 1) ? "royalblue" : "white";
                        
                        writer.WriteLine($"        <TD BGCOLOR=\"{colorFondo}\" WIDTH=\"20\" HEIGHT=\"20\"></TD>");
                    }
                    writer.WriteLine("      </TR>");
                }

                writer.WriteLine("    </TABLE>");
                writer.WriteLine("  >];");
                writer.WriteLine("}");
            }

            // 2. Ejecutamos el comando de Graphviz para generar el PNG
            ProcessStartInfo startInfo = new ProcessStartInfo("dot");
            startInfo.Arguments = $"-Tpng {rutaDot} -o {rutaPng}";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            using (Process proceso = Process.Start(startInfo))
            {
                proceso.WaitForExit(); // Esperamos a que termine de dibujar
            }

            Console.WriteLine($"\n Gráfica generada con éxito: {rutaPng} ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n Error al generar gráfica con Graphviz: " + ex.Message);
            Console.WriteLine(" Asegúrate de tener Graphviz instalado en tu computadora y agregado a las variables de entorno (PATH).");
        }
    }
}