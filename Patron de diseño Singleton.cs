public class Singleton
{
    // La instancia única del Singleton
    private static Singleton instance;

    // Bloqueo para garantizar que la creación de la instancia sea segura en entornos multiproceso
    private static readonly object lockObject = new object();

    // El constructor es privado para evitar la creación de instancias directamente
    private Singleton() { }

    // Método estático para obtener la instancia única del Singleton
    public static Singleton Instance
    {
        get
        {
            // Si la instancia aún no existe, la creamos
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    // Método de ejemplo del Singleton
    public void PrintMessage(string message)
    {
        Console.WriteLine("Singleton says: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Acceder a la instancia del Singleton
        Singleton singleton = Singleton.Instance;
        singleton.PrintMessage("Hello, Singleton!");

        // Intentar crear otra instancia (no funcionará)
        // Singleton anotherInstance = new Singleton(); // Esto dará un error de compilación

        // Acceder a la misma instancia nuevamente
        Singleton sameSingleton = Singleton.Instance;
        sameSingleton.PrintMessage("Using the same Singleton instance.");
    }
}
