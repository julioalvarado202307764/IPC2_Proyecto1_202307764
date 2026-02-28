using System;
using System.IO;

public class EscritorXML
{
    public void GenerarArchivo(ListaPacientes pacientes, string rutaSalida)
    {
        if (pacientes == null || pacientes.ObtenerTamano() == 0)
        {
            Console.WriteLine("\n No hay pacientes en memoria para generar el archivo.");
            return;
        }

        try
        {
            // Usamos StreamWriter para escribir el archivo línea por línea
            using (StreamWriter writer = new StreamWriter(rutaSalida))
            {
                writer.WriteLine("<pacientes>");

                for (int i = 0; i < pacientes.ObtenerTamano(); i++)
                {
                    Paciente p = pacientes.ObtenerEn(i);
                    writer.WriteLine("  <paciente>");
                    writer.WriteLine("      <datospersonales>");
                    writer.WriteLine($"          <nombre>{p.Nombre}</nombre>");
                    writer.WriteLine($"          <edad>{p.Edad}</edad>");
                    writer.WriteLine("      </datospersonales>");
                    writer.WriteLine($"      <periodos>{p.Periodos}</periodos>");
                    writer.WriteLine($"      <m>{p.M}</m>");

                    // Si no se ha simulado, ponemos un valor por defecto
                    string resultado = string.IsNullOrEmpty(p.Resultado) ? "sin_analizar" : p.Resultado;
                    writer.WriteLine($"      <resultado>{resultado}</resultado>");

                    // Escribimos N y N1 solo si la enfermedad es grave o mortal
                    if (resultado == "mortal" || resultado == "grave")
                    {
                        writer.WriteLine($"      <n>{p.N}</n>");

                        // Solo imprimimos N1 si es mayor a 0 (cuando el patrón repetido no es el inicial)
                        if (p.N1 > 0)
                        {
                            writer.WriteLine($"      <n1>{p.N1}</n1>");
                        }
                    }

                    writer.WriteLine("  </paciente>");
                }

                writer.WriteLine("</pacientes>");
            }
            Console.WriteLine($"\n Archivo XML de salida generado con éxito: {rutaSalida} ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n Error al guardar el archivo: " + ex.Message);
        }
    }
}