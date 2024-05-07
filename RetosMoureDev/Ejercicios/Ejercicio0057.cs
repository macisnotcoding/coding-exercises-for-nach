namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe un programa que, dado un número, compruebe y muestre si es primo,
    /// fibonacci y par.
    /// Ejemplos:
    /// - Con el número 2, nos dirá: "2 es primo, fibonacci y es par"
    /// - Con el número 7, nos dirá: "7 es primo, no es fibonacci y es impar"
    /// </summary>
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0057
    {
        public static void Run()
        {
            ExecuteLogic(2);
            ExecuteLogic(7);
            ExecuteLogic(0);
            ExecuteLogic(1);
            ExecuteLogic(-2);
        }

        private static void ExecuteLogic(int num)
        {
            Console.WriteLine("{0} {1} primo, {2} fibonacci y {3} par",
                num,
                EsPrimo(num).AsAffirmation(),
                EsFibonacci(num).AsAffirmation(),
                EsPar(num).AsAffirmation()
            );
        }

        //Copiado del Ejercicio0004
        private static bool EsPrimo(int num)
        {
            // Los números menores o iguales a 1 no son primos
            if (num <= 1)
            {
                return false;
            }

            // Comprobamos si el número es divisible por algún número menor que él
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    // Si es divisible, no es primo
                    return false;
                }
            }

            // Si no es divisible por ningún número menor que él, es primo
            return true;
        }

        //Un numero se considera fibonacci si es un cuadrado perfecto de 5*n^2 + 4 o 5*n^2 - 4 (propiedades de la secuencia)
        //Y si es positivo
        private static bool EsFibonacci(int num)
        {
            return (EsCuadradoPerfecto(5 * num * num + 4) || EsCuadradoPerfecto(5 * num * num - 4)) && num >= 0;
        }

        private static bool EsCuadradoPerfecto(int num)
        {
            double raiz = double.Round(Math.Sqrt(num));
            return raiz * raiz == num;
        }

        private static bool EsPar(int num)
        {
            return num % 2 == 0;
        }

        //En español me sonaba horrible, así que lo he dejado en inglés
        private static string AsAffirmation(this bool valor)
        {
            return valor ? "es" : "no es";
        }
    }
}