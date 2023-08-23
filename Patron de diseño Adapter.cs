using System;

// Interfaz moderna que se espera utilizar
public interface IPrinter
{
    void Print(string text);
}

// Clase antigua con interfaz incompatible
public class OldPrinter
{
    public void PrintLegacy(string text)
    {
        Console.WriteLine("Old Printer: " + text);
    }
}

// Adaptador que convierte la interfaz antigua en la moderna
public class PrinterAdapter : IPrinter
{
    private OldPrinter oldPrinter;

    public PrinterAdapter(OldPrinter oldPrinter)
    {
        this.oldPrinter = oldPrinter;
    }

    public void Print(string text)
    {
        // Llamamos al método de la interfaz antigua a través del adaptador
        oldPrinter.PrintLegacy(text);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la clase antigua
        OldPrinter oldPrinter = new OldPrinter();

        // Crear un adaptador que permita que la clase antigua funcione con la interfaz moderna
        IPrinter printerAdapter = new PrinterAdapter(oldPrinter);

        // Utilizar la interfaz moderna para imprimir
        printerAdapter.Print("Hello, Adapter Pattern!");

        // Resultado esperado:
        // Old Printer: Hello, Adapter Pattern!
    }
}
