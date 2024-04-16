namespace RetosMoureDev.View
{
    public static class ConsoleUI
    {
        private static readonly string separator = new('=', 80);

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                ¡Bienvenido a los -Retos by MoureDev-!                        ║");
            Console.WriteLine("║          Ejercicios resueltos por github.com/macisnotcoding                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
        }

        public static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine(separator);
            Console.WriteLine();
        }

        public static void PrintEndOfMenu()
        {
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static string? ExerciseInput()
        {
            Console.Write("Introduce el número del ejercicio (1-101) o escribe 'exit' para salir: ");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            var input = Console.ReadLine();
            Console.ResetColor();

            return input;
        }
    }
}