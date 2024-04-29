namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que retorne el número total de bumeranes de
    /// un array de números enteros e imprima cada uno de ellos.
    /// - Un bumerán (búmeran, boomerang) es una secuencia formada por 3 números
    ///   seguidos, en el que el primero y el último son iguales, y el segundo
    ///   es diferente. Por ejemplo [2, 1, 2].
    /// - En el array [2, 1, 2, 3, 3, 4, 2, 4] hay 2 bumeranes ([2, 1, 2]
    ///   y [4, 2, 4]).
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0045
    {
        public static void Run()
        {
            ExecuteLogic([2, 1, 2, 3, 3, 4, 2, 4]);
            ExecuteLogic([2, 1, 2, 1, 2]);
            ExecuteLogic([1, 2, 3, 4, 5]);
            ExecuteLogic([2, 2, 2, 2, 2]);
            ExecuteLogic([2, -2, 2, -2, 2]);
            ExecuteLogic([2, -2]);
            ExecuteLogic([2]);
            ExecuteLogic([]);
        }

        private static void ExecuteLogic(int[] numeros)
        {
            var bumeranes = EncontrarBumeranes(numeros);
            Console.WriteLine($"En el array [{string.Join(", ", numeros)}] hay {bumeranes.Count} bumeranes");
            bumeranes.ForEach(x => Console.WriteLine($"[{string.Join(", ", x)}]"));
        }

        private static List<int[]> EncontrarBumeranes(int[] numeros)
        {
            List<int[]> result = new();

            if (numeros.Length >= 3)
            {
                for (int i = 2; i < numeros.Length; i++)
                {
                    int primero = numeros[i - 2];
                    int segundo = numeros[i - 1];
                    int tercero = numeros[i];

                    if (tercero == primero && tercero != segundo)
                    {
                        int[] bumeran = [primero, segundo, tercero];
                        if (!result.ContieneBumeran(bumeran))
                        {
                            result.Add(bumeran);
                        }
                    }
                }
            }

            return result;
        }

        //Metodo auxiliar para evitar añadir bumeranes duplicados
        private static bool ContieneBumeran(this List<int[]> lista, int[] nuevoBumeran)
        {
            foreach (var bumeran in lista)
            {
                if (bumeran[0] == nuevoBumeran[0] && bumeran[1] == nuevoBumeran[1] && bumeran[2] == nuevoBumeran[2])
                {
                    return true;
                }
            }
            return false;
        }
    }
}