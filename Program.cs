using System;

class Program
{
    // Variables globales para mantener el estado durante la ejecución
    static ListaEnlazada<Paciente> misPacientes = new ListaEnlazada<Paciente>();
    static Paciente pacienteActual = null;

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("  SIMULADOR EPIDEMIOLÓGICO  ");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Cargar archivo XML de pacientes");
            Console.WriteLine("2. Elegir un paciente para su análisis");
            Console.WriteLine("3. Simulación paso a paso (1 período)");
            Console.WriteLine("4. Simulación automática completa");
            Console.WriteLine("5. Limpiar datos en memoria");
            Console.WriteLine("6. Generar archivo XML de salida");
            Console.WriteLine("7. Salir");
            Console.Write("\nElige una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingresa la ruta del archivo (o presiona Enter para usar 'entrada.xml'): ");
                    string ruta = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ruta)) ruta = "entrada.xml";
                    
                    LectorXML lector = new LectorXML();
                    misPacientes = lector.CargarPacientes(ruta);
                    break;

                case "2":
                    ElegirPaciente();
                    break;

                case "3":
                    if (pacienteActual != null)
                    {
                        Simulador sim = new Simulador();
                        sim.SimularUnPeriodo(pacienteActual);
                        Console.WriteLine($"\n Simulación avanzada 1 período.");
                        Console.WriteLine($"Celdas enfermas actuales: {pacienteActual.Rejilla.ObtenerTamano()}");
                    }
                    else
                    {
                        Console.WriteLine("\n  Primero debes elegir un paciente (Opción 2).");
                    }
                    break;

                case "4":
                    if (pacienteActual != null)
                    {
                        Simulador simAuto = new Simulador();
                        Console.WriteLine("\nIniciando análisis automático...");
                        simAuto.AnalizarEnfermedad(pacienteActual);
                    }
                    else
                    {
                        Console.WriteLine("\n Primero debes elegir un paciente (Opción 2).");
                    }
                    break;

                case "5":
                    misPacientes.Limpiar(); // Usamos el método que creamos en nuestro TDA
                    pacienteActual = null;
                    Console.WriteLine("\n Memoria limpiada con éxito.");
                    break;

                case "6":
                    Console.WriteLine("\n Opción en construcción... (¡Nuestro próximo paso!)");
                    break;

                case "7":
                    salir = true;
                    Console.WriteLine("\n¡Nos vemos! Éxitos en el proyecto. ");
                    break;

                default:
                    Console.WriteLine("\n Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }

    // Método auxiliar para mostrar y seleccionar pacientes
    static void ElegirPaciente()
    {
        if (misPacientes == null || misPacientes.ObtenerTamano() == 0)
        {
            Console.WriteLine("\n No hay pacientes cargados. Usa la opción 1 primero.");
            return;
        }

        Console.WriteLine("\n--- Pacientes Disponibles ---");
        for (int i = 0; i < misPacientes.ObtenerTamano(); i++)
        {
            Paciente p = misPacientes.ObtenerEn(i);
            Console.WriteLine($"{i + 1}. {p.Nombre} (Rejilla: {p.M}x{p.M})");
        }
        
        Console.Write("\nIngresa el número del paciente que deseas analizar: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= misPacientes.ObtenerTamano())
        {
            pacienteActual = misPacientes.ObtenerEn(indice - 1);
            Console.WriteLine($"\n Paciente seleccionado: {pacienteActual.Nombre}");
        }
        else
        {
            Console.WriteLine("\n Selección inválida.");
        }
    }
}