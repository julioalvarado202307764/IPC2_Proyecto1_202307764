public class Paciente
{
    // Datos Personales
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    // Configuración de la simulación
    public int Periodos { get; set; }
    public int M { get; set; } // Tamaño de la rejilla M x M
    
    // ¡Nuestra estructura personalizada en acción!
    public ListaEnlazada<Celda> Rejilla { get; set; }

    // Datos para el archivo XML de salida
    public string Resultado { get; set; } // "leve", "grave", o "mortal"
    public int N { get; set; }
    public int N1 { get; set; }

    public Paciente(string nombre, int edad, int periodos, int m)
    {
        Nombre = nombre;
        Edad = edad;
        Periodos = periodos;
        M = m;
        Rejilla = new ListaEnlazada<Celda>();
        
        // Inicializamos los valores de salida por defecto
        Resultado = "";
        N = 0;
        N1 = 0;
    }
}