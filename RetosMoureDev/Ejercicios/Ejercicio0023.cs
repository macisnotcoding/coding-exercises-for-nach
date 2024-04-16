namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que reciba dos array de int, un booleano y retorne un array.
    /// - Si el booleano es verdadero buscará y retornará los elementos comunes
    ///   de los dos array.
    /// - Si el booleano es falso buscará y retornará los elementos no comunes
    ///   de los dos array.
    /// - No se pueden utilizar operaciones del lenguaje que
    ///   lo resuelvan directamente.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0023
    {
        public static void Run()
        {
            ExecuteLogic([1, 2, 3, 3, 4], [2, 2, 3, 3, 4, 6], true);
            ExecuteLogic([1, 2, 3, 3, 4], [2, 2, 3, 3, 4, 6], false);
        }

        private static void ExecuteLogic(int[] array1, int[] array2, bool comunes)
        {
            Console.WriteLine($"Conjunto de numeros 1: {string.Join(", ", array1)}");
            Console.WriteLine($"Conjunto de numeros 2: {string.Join(", ", array2)}");

            if (comunes)
            {
                Console.WriteLine($"Los elementos comunes entre ambos son: {string.Join(", ", BuscarElementosComunes(array1, array2))}");
            }
            else
            {
                Console.WriteLine($"Los elementos no comunes entre ambos son: {string.Join(", ", BuscarElementosNoComunes(array1, array2))}");
            }
        }

        private static int[] BuscarElementosComunes(int[] array1, int[] array2)
        {
            var resultado = new HashSet<int>();

            foreach (int i in array1)
            {
                foreach (int j in array2)
                {
                    if (i == j)
                    {
                        resultado.Add(i);
                        break;
                    }
                }
            }

            return resultado.ToArray();
        }

        private static int[] BuscarElementosNoComunes(int[] array1, int[] array2)
        {
            var resultado = new HashSet<int>();

            // Verificar elementos de array1 que no están en array2
            foreach (int i in array1)
            {
                bool encontrado = false;
                foreach (int j in array2)
                {
                    if (j == i)
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    resultado.Add(i);
                }
            }

            // Verificar elementos de array2 que no están en array1
            foreach (int i in array2)
            {
                bool encontrado = false;
                foreach (int j in array1)
                {
                    if (j == i)
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    resultado.Add(i);
                }
            }

            return resultado.ToArray();
        }
    }
}