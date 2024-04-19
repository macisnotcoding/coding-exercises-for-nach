namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que sea capaz de dibujar el "Triángulo de Pascal"
    /// indicándole únicamente el tamaño del lado.
    /// - Aquí puedes ver rápidamente cómo se calcula el triángulo:
    /// https://commons.wikimedia.org/wiki/File:PascalTriangleAnimated2.gif
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0041
    {
        public static void Run()
        {
            ExecuteLogic(5);
            ExecuteLogic(1);
            ExecuteLogic(0);
            ExecuteLogic(-5);
            ExecuteLogic(10);
        }

        private static void ExecuteLogic(int sizeLado)
        {
            Console.WriteLine($"El triangulo de Pascal de tamaño {sizeLado}:");
            DibujarTrianguloPascal(sizeLado);
        }

        private static void DibujarTrianguloPascal(int sizeLado)
        {
            List<int> filaAnterior = [];

            for(int fila = 0; fila < sizeLado; fila++)
            {
                List<int> filaActual = [];
                string filaStr = string.Empty;

                for(int elemento = 0; elemento <= fila; elemento++) 
                {
                    if (elemento > 0 && elemento < fila)
                    {
                        int valor = filaAnterior[elemento -1] + filaAnterior[elemento];
                        filaActual.Add(valor);
                        filaStr += valor + " ";
                    }
                    else //Estamos en los bordes
                    {
                        filaActual.Add(1);
                        filaStr += "1 ";
                    }
                }

                Console.WriteLine(new string(' ', sizeLado - fila) + filaStr);

                filaAnterior = filaActual;
                //APUNTE: Esta forma es para practicar LINQ y eliminar la necesidad de la lista "filaActual,
                //pero es mucho menos eficiente en comparacion
                //filaAnterior = filaStr.Split(' ')
                //    .Where(x => !string.IsNullOrWhiteSpace(x))
                //    .Select(x => Convert.ToInt32(x))
                //    .ToList();
            }
        }
    }
}