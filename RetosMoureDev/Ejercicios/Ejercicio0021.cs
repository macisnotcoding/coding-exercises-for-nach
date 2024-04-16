namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que sume 2 números y retorne su resultado pasados
    /// unos segundos.
    /// - Recibirá por parámetros los 2 números a sumar y los segundos que
    ///   debe tardar en finalizar su ejecución.
    /// - Si el lenguaje lo soporta, deberá retornar el resultado de forma
    ///   asíncrona, es decir, sin detener la ejecución del programa principal.
    ///   Se podría ejecutar varias veces al mismo tiempo.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0021
    {
        public static void Run()
        {
            RunAsync().Wait(); // Espera a que RunAsync finalice para continuar con el programa principal
        }

        public static async Task RunAsync()
        {
            Task tarea1 = ExecuteLogic(5, 2, 10);
            Task tarea2 = ExecuteLogic(1, 3, 5);
            await Task.WhenAll(tarea1, tarea2);  // Espera a que todas las tareas finalicen antes de parar el programa
        }

        private static async Task ExecuteLogic(int num1, int num2, int secsAEsperar)
        {
            Console.WriteLine($"La suma de {num1} y {num2} se va a realizar dentro de {secsAEsperar} segundos");
            int suma = await SumarConEspera(num1, num2, secsAEsperar);
            Console.WriteLine($"El resultado es {suma}");
        }

        public static async Task<int> SumarConEspera(int num1, int num2, int secsAEsperar)
        {
            await Task.Delay(secsAEsperar * 1000);
            return num1 + num2;
        }
    }
}