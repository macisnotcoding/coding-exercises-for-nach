namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que determine si dos vectores son ortogonales.
    /// - Los dos array deben tener la misma longitud.
    /// - Cada vector se podría representar como un array. Ejemplo: [1, -2]
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil <br/>
    /// <a href="https://es.wikipedia.org/wiki/Ortogonalidad_(matem%C3%A1tica)#:~:text=Ortogonalidad%20y%20perpendicularidad%5B,partir%20del%20producto%20interior.">Que es y como se averigua la ortogonalidad</a>
    /// </remarks>
    public static class Ejercicio0028
    {
        public static void Run()
        {
            ExecuteLogic([1, 2], [2, 1]);
            ExecuteLogic([2, 1], [-1, 2]);
            ExecuteLogic([2, 1, 3], [-1, 2]);
            ExecuteLogic([2, 1, 3], [3, 4, 8]);
        }

        private static void ExecuteLogic(List<int> vector1, List<int> vector2)
        {
            if (vector1.Count != vector2.Count)
            {
                Console.WriteLine($"Los vectores ({string.Join(", ", vector1)}) y ({string.Join(", ", vector2)}) NO son ortogonales porque tienen dimensiones distintas");
            }
            else
            {
                //Version iterativa
                //int productoEscalar = 0;
                //for(int i = 0; i < vector1.Count; i++)
                //{
                //    productoEscalar += vector1[i] * vector2[i];
                //}

                //Version con LINQ
                int productoEscalar = vector1.Zip(vector2, (v1, v2) => v1 * v2).Sum();

                Console.WriteLine($"Los vectores ({string.Join(", ", vector1)}) y ({string.Join(", ", vector2)}) {(productoEscalar == 0 ? "SI" : "NO")} son ortogonales");
            }
        }
    }
}