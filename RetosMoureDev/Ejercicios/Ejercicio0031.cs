namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que reciba un texto y muestre cada palabra en una línea,
    /// formando un marco rectangular de asteriscos.
    /// - ¿Qué te parece el reto? Se vería así:
    ///   **********
    ///   * ¿Qué   *
    ///   * te     *
    ///   * parece *
    ///   * el     *
    ///   * reto?  *
    ///   **********
    /// </summary>
    /// <remarks>
    /// Dificultad: Facil
    /// </remarks>
    public static class Ejercicio0031
    {
        public static void Run()
        {
            // Ejecutar la lógica del ejercicio
            ExecuteLogic("¿Qué te parece el reto?");
            ExecuteLogic("¿Qué te     parece el reto?");
            ExecuteLogic("¿Cuántos retos de código de la comunidad has resuelto?");
        }

        private static void ExecuteLogic(string texto)
        {
            string[] palabras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int maxLongitud = palabras.Max(p => p.Length);
            string separador = new string('*', maxLongitud + 4);

            Console.WriteLine(separador);
            foreach(string palabra in palabras)
            {
                Console.WriteLine($"* {palabra}{new string(' ', maxLongitud - palabra.Length)} *");
            }
            Console.WriteLine(separador);
        }
    }
}