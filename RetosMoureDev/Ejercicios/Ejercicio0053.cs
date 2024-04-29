namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe un programa que muestre por consola(con un print) los
    /// números de 1 a 100 (ambos incluidos y con un salto de línea entre
    /// cada impresión), sustituyendo los siguientes:
    /// - Múltiplos de 3 por la palabra "fizz".
    /// - Múltiplos de 5 por la palabra "buzz".
    /// - Múltiplos de 3 y de 5 a la vez por la palabra "fizzbuzz".
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Facil
    /// </remarks>
    public static class Ejercicio0053
    {
        public static void Run()
        {
            ExecuteLogic();
        }

        public static void ExecuteLogic()
        {
            for (int i = 1; i <= 100; i++)
            {
                string output = string.Empty;

                if (i % 3 == 0)
                {
                    output += "fizz";
                }

                if (i % 5 == 0)
                {
                    output += "buzz";
                }

                if (string.IsNullOrWhiteSpace(output))
                {
                    output = i.ToString();
                }

                Console.WriteLine(output);
            }
        }
    }
}