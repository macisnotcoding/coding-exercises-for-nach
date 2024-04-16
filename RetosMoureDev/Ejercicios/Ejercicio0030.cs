namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que ordene y retorne una matriz de números.
    /// - La función recibirá un listado (por ejemplo [2, 4, 6, 8, 9]) y un parámetro
    ///   adicional "Asc" o "Desc" para indicar si debe ordenarse de menor a mayor
    ///   o de mayor a menor.
    /// - No se pueden utilizar funciones propias del lenguaje que lo resuelvan
    ///   automáticamente.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Facil
    /// </remarks>
    public static class Ejercicio0030
    {
        public static void Run()
        {
            ExecuteLogic([4, 6, 1, 8, 2], true);
            ExecuteLogic([4, 6, 1, 8, 2], false);
        }

        private static void ExecuteLogic(int[] listado, bool ordenarAsc)
        {
            Console.WriteLine($"Listado original {{{string.Join(", ", listado)}}}");
            listado.Ordenar(ordenarAsc);
            Console.WriteLine($"Listado ordenado {(ordenarAsc ? "ascendentemente" : "descendentemente")} {{{string.Join(", ", listado)}}}");
        }

        /// <summary>
        /// Ordena una lista siguiendo el algoritmo Bubble sort.
        /// </summary>
        /// 
        /// <remarks>
        /// Hay muchas formas y colores de ordenar una lista. Muchos muchos algoritmos, todos mas o menos eficientes.
        /// Yo he utilizado el mas sencillo de todos, "Bubble sort". Puedes echar un ojo <a href="https://www.geeksforgeeks.org/bubble-sort/">en esta web para entender como funciona</a>  
        /// </remarks>
        /// <param name="listado">Lista de enteros a ordenar</param>
        /// <param name="ordenarAsc">Indica si se debe ordenar de menor a mayor (true) o de mayor a menor (false)</param>
        private static void Ordenar(this int[] listado, bool ordenarAsc)
        {
            for (int i = 0; i < listado.Length; i++)
            {
                for (int j = 0; j < listado.Length - 1; j++)
                {
                    //variamos la condicion del if en funcion de si es Asc o Desc para no escribir dos veces la misma logica
                    if (ordenarAsc ? listado[j] > listado[j + 1] : listado[j] < listado[j + 1])
                    {
                        //Si se cumple la condicion, los intercambiamos de posicion
                        int temp = listado[j];
                        listado[j] = listado[j + 1];
                        listado[j + 1] = temp;
                    }
                }
            }
        }
    }
}