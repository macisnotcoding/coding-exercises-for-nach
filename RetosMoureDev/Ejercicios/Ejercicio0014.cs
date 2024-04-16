namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe una función que calcule y retorne el factorial de un número dado
    /// de forma recursiva.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0014
    {
        public static void Run()
        {
            ExecuteLogic(10);
        }

        private static void ExecuteLogic(int num)
        {
            Console.WriteLine($"El factorial de {num} es {CalculaFactorial(num)}");
        }

        private static int CalculaFactorial(int N)
        {
            //Caso base
            if (N == 1)
                return N;
            else
                return N * CalculaFactorial(N - 1);
        }
    }
}