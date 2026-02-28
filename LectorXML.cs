using System;
using System.Xml;

public class LectorXML
{
    public ListaPacientes CargarPacientes(string rutaArchivo)
    {
        // Instanciamos nuestra lista personalizada
        ListaPacientes listaPacientes = new ListaPacientes();
        XmlDocument doc = new XmlDocument();
        
        try
        {
            doc.Load(rutaArchivo);
            
            // Buscamos todos los nodos <paciente> dentro del XML
            XmlNodeList nodosPaciente = doc.SelectNodes("//paciente");

            if (nodosPaciente != null)
            {
                foreach (XmlNode nodo in nodosPaciente)
                {
                    // Extraemos los datos básicos del paciente
                    string nombre = nodo.SelectSingleNode("datospersonales/nombre")?.InnerText;
                    int edad = int.Parse(nodo.SelectSingleNode("datospersonales/edad")?.InnerText ?? "0");
                    int periodos = int.Parse(nodo.SelectSingleNode("periodos")?.InnerText ?? "0");
                    
                    // Extraemos el tamaño de la rejilla (M)
                    int m = int.Parse(nodo.SelectSingleNode("m")?.InnerText ?? "0");

                    // Creamos el objeto Paciente
                    Paciente nuevoPaciente = new Paciente(nombre, edad, periodos, m);

                    // Buscamos las celdas contagiadas iniciales
                    XmlNodeList nodosCelda = nodo.SelectNodes("rejilla/celda");
                    if (nodosCelda != null)
                    {
                        foreach (XmlNode nodoCelda in nodosCelda)
                        {
                            // Obtenemos los atributos f (fila) y c (columna)
                            int fila = int.Parse(nodoCelda.Attributes["f"].Value);
                            int columna = int.Parse(nodoCelda.Attributes["c"].Value);
                            
                            // Agregamos la celda contagiada (estado 1) a la lista del paciente
                            nuevoPaciente.Rejilla.Agregar(new Celda(fila, columna, 1));
                        }
                    }

                    // Finalmente, guardamos el paciente en nuestra lista principal
                    listaPacientes.Agregar(nuevoPaciente);
                }
            }
            Console.WriteLine("¡Archivo XML cargado con éxito! 🔥");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer el archivo XML: " + ex.Message);
        }

        return listaPacientes;
    }
}