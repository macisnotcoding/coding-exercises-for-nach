namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea dos funciones, una que calcule el máximo común divisor (MCD) y otra
    /// que calcule el mínimo común múltiplo (mcm) de dos números enteros.
    /// - No se pueden utilizar operaciones del lenguaje que
    ///   lo resuelvan directamente.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0024
    {
        public static void Run()
        {
            ExecuteLogic(56, 180);
        }

        private static void ExecuteLogic(int num1, int num2)
        {
            Console.WriteLine($"El MCD de {num1} y {num2} es {MCD(num1, num2)}");
            Console.WriteLine($"El mcm de {num1} y {num2} es {mcm(num1, num2)}");
        }

        /// <summary>
        /// Calcula el MCD de dos enteros utilizando el metodo del algoritmo de Euclides
        /// </summary>
        /// 
        /// <remarks>
        /// <a href="https://es.wikipedia.org/wiki/Algoritmo_de_Euclides">Explicacion del algoritmo de Euclides</a>
        /// </remarks>
        private static int MCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        // Función para calcular el mínimo común múltiplo
        // Se utiliza la fórmula mcm(a, b) = |a * b| / MCD(a, b)
        private static int mcm(int num1, int num2)
        {
            return Math.Abs(num1 * num2) / MCD(num1, num2);
        }
    }
}