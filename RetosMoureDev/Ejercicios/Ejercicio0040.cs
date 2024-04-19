namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Implementa uno de los algoritmos de ordenación más famosos:
    /// el "Quick Sort", creado por C.A.R. Hoare.
    /// - Entender el funcionamiento de los algoritmos más utilizados de la historia
    ///   nos ayuda a mejorar nuestro conocimiento sobre ingeniería de software.
    ///   Dedícale tiempo a entenderlo, no únicamente a copiar su implementación.
    /// - Esta es una nueva serie de retos llamada "TOP ALGORITMOS",
    ///   donde trabajaremos y entenderemos los más famosos de la historia.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0040
    {
        public static void Run()
        {
            ExecuteLogic([3, 5, 1, 8, 9, 0]);
        }

        private static void ExecuteLogic(int[] numeros)
        {
            Console.WriteLine($"Array original: [{string.Join(", ", numeros)}]");
            QuickSort(numeros, 0, numeros.Length - 1);
            Console.WriteLine($"Array ordenado con QuickSort: [{string.Join(", ", numeros)}]");
        }


        //Este metodo se encarga de ordenar el array
        //mediante el algoritmo QuickSort
        //Recibe el array y los indices del primero y el ultimo
        //para poder dividir el array en dos secciones
        //y ordenarlas de forma recursiva
        //hasta que solo quede un elemento en cada seccion
        //y el array este ordenado

        private static void QuickSort(int[] numeros, int primerIndice, int ultimoIndice)
        {
            //Si el primer indice es menor al ultimo indice
            //Significa que hay mas de un elemento en el array
            //y por lo tanto podemos seguir dividiendo
            //Si no, significa que solo hay un elemento y no hay nada que ordenar
            if ( primerIndice < ultimoIndice)
            {
                //Obtenemos el pivote
                //El pivote es el elemento que se va a comparar con los demas
                //para dividir el array en dos secciones
                //Los elementos menores al pivote iran a la izquierda
                //Los elementos mayores al pivote iran a la derecha
                int pivote = Trocear(numeros, primerIndice, ultimoIndice);

                QuickSort(numeros, primerIndice, pivote - 1);
                QuickSort(numeros, pivote + 1, ultimoIndice);
            }
        }

        //Este metodo se encarga de dividir el array en dos secciones
        //y colocar el pivote en su posicion final
        //Devuelve la posicion del pivote
        //para que se pueda dividir el array en dos secciones
        //y ordenarlas de forma recursiva
        //hasta que solo quede un elemento en cada seccion
        //y el array este ordenado
        private static int Trocear(int[] numeros, int primerIndice, int ultimoIndice)
        {
            //Tomamos el ultimo elemento como pivote
            int pivote = numeros[ultimoIndice];
            //Tomamos el primer indice - 1 como el indice mas bajo
            //para comparar con el pivote
            int i = primerIndice - 1;

            //Recorremos el array desde el primer indice hasta el ultimo indice
            for (int j = primerIndice; j < ultimoIndice; j++)
            {
                //Si el elemento actual es menor i igual al pivote
                if (numeros[j] <= pivote)
                {
                    i++;

                    //Intercambiamos el elemento en i con el elemento en j
                    //para que los elementos menores al pivote queden a la izquierda
                    //y los elementos mayores al pivote queden a la derecha
                    numeros.Intercambiar(i, j);
                }
            }

            //Intercambiamos el elemento en i + 1 con el pivote
            //para que el pivote quede en su posicion final
            //y los elementos menores al pivote queden a la izquierda
            //y los elementos mayores al pivote queden a la derecha
            numeros.Intercambiar(i + 1, ultimoIndice);

            return i + 1; //Devolvemos la posicion del nuevo pivote
        }

        private static void Intercambiar(this int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}