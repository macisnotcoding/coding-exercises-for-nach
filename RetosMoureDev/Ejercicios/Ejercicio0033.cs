namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Dado un listado de números, encuentra el SEGUNDO más grande.
    /// </summary>
    /// <remarks>
    /// Dificultad: Facil
    /// </remarks>
    public static class Ejercicio0033
    {
        public static void Run()
        {
            ExecuteLogic([4, 6, 1, 8, 2]);
            ExecuteLogic([4, 6, 8, 8, 6]);
            ExecuteLogic([4, 4]);
            ExecuteLogic([]);
        }

        private static void ExecuteLogic(List<int> numeros)
        {
            int primero = 0;
            int segundo = 0;

            foreach (int numero in numeros)
            {
                if (numero > primero)
                {
                    segundo = primero;
                    primero = numero;
                }
                else if( numero > segundo && numero != primero)
                {
                    segundo = numero;
                }
            }

            if(segundo != 0)
            {
                Console.WriteLine($"El segundo valor más grande en {{{string.Join(", ", numeros)}}} es el {segundo}");
            }
            else
            {
                Console.WriteLine($"No hay suficientes elementos únicos en la lista {{{string.Join(", ", numeros)}}} como para determinar un segundo más grande");
            }
        }
    }
}