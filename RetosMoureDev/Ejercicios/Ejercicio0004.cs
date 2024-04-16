namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe un programa que se encargue de comprobar si un número es o no primo.
    /// Hecho esto, imprime los números primos entre 1 y 100.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public class Ejercicio0004
    {
        public static void Run()
        {
            ExecuteLogic();
        }

        private static void ExecuteLogic()
        {
            Console.WriteLine("Los números primos entre 1 y 100 son:");

            for (int i = 1; i <= 100; i++)
            {
                if (EsPrimo(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

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
    }
}