namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Quiero contar del 1 al 100 de uno en uno (imprimiendo cada uno).
    /// ¿De cuántas maneras eres capaz de hacerlo?
    /// Crea el código para cada una de ellas.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0025
    {
        public static void Run()
        {
            ExecuteLogic();
        }

        private static void ExecuteLogic()
        {
            // 1 Uso de un bucle for clasico:
            Console.WriteLine("**** 1 ****");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }
            // 2 Uso de un bucle while:
            Console.WriteLine("**** 2 ****");
            int j = 1;
            while (j <= 100)
            {
                Console.WriteLine(j);
                j++;
            }

            // 3 Uso de un bucle do-while:
            Console.WriteLine("**** 3 ****");
            int k = 1;
            do
            {
                Console.WriteLine(k);
                k++;
            } while (k <= 100);

            // 4 Uso de foreach con Enumerable.Range:
            Console.WriteLine("**** 4 ****");
            foreach (int num in Enumerable.Range(1, 100))
            {
                Console.WriteLine(num);
            }

            // 5 Uso de for con un paso personalizado:
            Console.WriteLine("**** 5 ****");
            for (int l = 1; l <= 100; l += 1) // Aquí el paso es 1, pero puedes modificarlo.
            {
                Console.WriteLine(l);
            }

            // 6 Uso de Parallel.For para una iteración paralela (útil para tareas que se pueden paralelizar):
            Console.WriteLine("**** 6 ****");
            Parallel.For(1, 101, m =>
            {
                Console.WriteLine(m);
            });

            // 7 Uso de recursión (no recomendado para este rango grande debido al riesgo de desbordamiento de pila):
            Console.WriteLine("**** 7 ****");
            PrintRecursively(1);

            // 8 Uso de LINQ:
            Console.WriteLine("**** 8 ****");
            Enumerable.Range(1, 100).ToList().ForEach(num => Console.WriteLine(num));

        }

        private static void PrintRecursively(int index)
        {
            if (index <= 100)
            {
                Console.WriteLine(index);
                PrintRecursively(index + 1);
            }
        }
    }
}