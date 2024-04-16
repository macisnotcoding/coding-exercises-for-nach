namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe un programa que imprima los 50 primeros números de la sucesión
    /// de Fibonacci empezando en 0.
    /// - La serie Fibonacci se compone por una sucesión de números en
    ///   la que el siguiente siempre es la suma de los dos anteriores.
    ///   0, 1, 1, 2, 3, 5, 8, 13...
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Dificil
    /// </remarks>
    public class Ejercicio0003
    {
        public static void Run()
        {
            Console.WriteLine("Los 50 primeros números de la sucesión de Fibonacci son: ");
            ExecuteLogic();
        }

        private static void ExecuteLogic()
        {
            //Usamos long en vez de int porque los numeros de la sucesión de Fibonacci pueden ser muy grandes y no cabrían en un int
            long n1 = 0;
            long n2 = 1;
            
            Console.WriteLine("1: {0}", n1);
            Console.WriteLine("2: {0}", n2);

            //Empezamos en 2 porque ya hemos impreso los dos primeros numeros
            for (int i = 2; i < 50; i++)
            {
                //Calculamos el siguiente numero de la sucesion
                long n3 = n1 + n2;
                Console.WriteLine("{0}: {1}", i + 1, n3);

                //Actualizamos los valores para la siguiente iteracion
                n1 = n2;
                n2 = n3;
            }
        }
    }
}