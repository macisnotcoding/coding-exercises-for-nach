namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea tu propio enunciado para que forme parte de los retos de 2023.
    /// <b>ok, aguantame el cubata: enunciado por macisnotcoding:</b>
    /// 
    /// Escribe un programa que reciba un array ordenado de números enteros y un número objetivo.
    /// El objetivo del programa es encontrar dos números en el array que sumados sean igual al número objetivo.
    /// Si se encuentran los dos números, el programa debe devolver sus índices en el array.
    /// Si no se encuentran dos números que cumplan la condición, el programa debe devolver un mensaje indicando que no se encontraron.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// Pista: TwoPointer II
    /// </remarks>
    public static class Ejercicio0052
    {
        public static void Run()
        {
            ExecuteLogic([2, 7, 11, 15], 18);
            ExecuteLogic([1, 2, 3, 4, 5], 9);
            ExecuteLogic([-3, 0, 1, 4, 6], 3);
            ExecuteLogic([2, 4, 6, 8], 10);
            ExecuteLogic([1, 3, 5, 7, 9], 13);
        }

        private static void ExecuteLogic(int[] numeros, int objetivo)
        {
            (int indiceSum1, int indiceSum2) indicesSumatorios = EncontrarSumatorios(numeros, objetivo);

            if(indicesSumatorios.indiceSum1 == indicesSumatorios.indiceSum2)
            {
                Console.WriteLine($"El array {{{string.Join(", ", numeros)}}} no contiene numeros cuya suma sea igual a {objetivo}");
            }
            else
            {
                Console.WriteLine("El {0}({1}) y el {2}({3}) del array {{{4}}} suman el valor objetivo {5}",
                    numeros[indicesSumatorios.indiceSum1],
                    indicesSumatorios.indiceSum1,
                    numeros[indicesSumatorios.indiceSum2],
                    indicesSumatorios.indiceSum2,
                    string.Join(", ", numeros),
                    objetivo
                );
            }
        }

        private static (int, int) EncontrarSumatorios(int[] numeros, int objetivo)
        {
            int L = 0;
            int R = numeros.Length - 1;

            while(L < R)
            {
                int suma = numeros[L] + numeros[R];

                if (suma == objetivo)
                {
                    break;
                }
                else if(suma < objetivo)
                {
                    L++;
                }
                else
                {
                    R--;
                }
            }

            return (L, R);
        }
    }
}