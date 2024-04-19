namespace RetosMoureDev.Ejercicios
{
    ///<summary>
    /// Dado un array de enteros ordenado y sin repetidos,
    /// crea una función que calcule y retorne todos los números que faltan entre
    /// el mayor y el menor.
    /// - Lanza un error si el array de entrada no es correcto.
    ///</summary>
    ///
    ///<remarks>
    /// Dificultad: Medio
    ///</remarks>
    public static class Ejercicio0035
    {
        public class NumerosPerdidosException(string message) : Exception(message)
        {
        }

        public static void Run()
        {
            ExecuteLogic([1, 3, 5]);
            ExecuteLogic([5, 3, 1]);
            ExecuteLogic([5, 1]);
            ExecuteLogic([-5, 1]);
            ExecuteLogic([1, 3, 3, 5]);
            ExecuteLogic([5, 7, 1]);
            ExecuteLogic([10, 7, 7, 1]);
        }

        private static void ExecuteLogic(int[] numeros)
        {
            try
            {
                VerificarRestricciones(numeros);
                List<int> numerosPerdidos = ObtenerNumerosPerdidos(numeros);

                if (numerosPerdidos.Count != 0)
                {
                    Console.WriteLine($"Los numeros perdidos en el set de numeros [{string.Join(", ", numeros)}] son {{{string.Join(", ", numerosPerdidos)}}}");
                }
                else
                {
                    Console.WriteLine($"No falta ningun numero en el set de numeros [{string.Join(", ", numeros)}]");
                }
            }
            catch (NumerosPerdidosException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Set: [{string.Join(", ", numeros)}]");
            }
        }

        private static List<int> ObtenerNumerosPerdidos(int[] numeros)
        {
            //La restriccion es usar de entrada un array, pero no dice nada del set de salida.. asi que usamos List para aprovechar
            //la no necesidad de definir el tamaño y la función de add()
            var numerosPerdidos = new List<int>();
            bool esOrdenAscendente = numeros[0] < numeros[numeros.Length - 1];
            for (int i = 1; i <= numeros.Length -1; i++)
            {
                //Calculamos la diferencia entre el numero actual y el anterior
                //Si la diferencia > 1 significa que no son consecutivos y faltan numeros entre medias
                int diferencia = Math.Abs(numeros[i] - numeros[i - 1]);
                if(diferencia > 1)
                {
                    //Anadimos los numeros que falten entre el numero actual y el anterior
                    for(int j = 1; j < diferencia; j++)
                    {
                        int numeroPerdido = esOrdenAscendente ? numeros[i - 1] + j : numeros[i - 1] - j;
                        numerosPerdidos.Add(numeroPerdido);
                    }
                }
            }

            return numerosPerdidos;
        }

        private static void VerificarRestricciones(int[] numeros)
        {
            if (numeros.Length < 2)
            {
                throw new NumerosPerdidosException($"El set de numeros tiene menos de dos elementos");
            }

            int primero = numeros[0];
            int ultimo = numeros[numeros.Length - 1];
            bool esOrdenAscendente = primero < ultimo;
            int? previo = null;

            //Comprobamos que efectivamente el set esta ordenado y no tiene duplicados
            foreach (int numero in numeros)
            {
                if (previo.HasValue)
                {
                    if (numero == previo)
                    {
                        throw new NumerosPerdidosException($"El set de numeros tiene duplicado el valor {numero}");
                    }
                    if ((esOrdenAscendente && numero <= previo) || (!esOrdenAscendente && numero >= previo))
                    {
                        throw new NumerosPerdidosException($"El set de numeros no está ordenado");
                    }
                }
                previo = numero;
            }
        }
    }
}