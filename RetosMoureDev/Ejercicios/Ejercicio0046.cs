namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Dado un array de números enteros positivos, donde cada uno
    /// representa unidades de bloques apilados, debemos calcular cuántas unidades
    /// de agua quedarán atrapadas entre ellos.
    ///
    /// - Ejemplo: Dado el array [4, 0, 3, 6, 1, 3].
    ///
    ///         ⏹
    ///         ⏹
    ///   ⏹💧💧⏹
    ///   ⏹💧⏹⏹💧⏹
    ///   ⏹💧⏹⏹💧⏹
    ///   ⏹💧⏹⏹⏹⏹
    ///
    ///   Representando bloque con ⏹ y agua con 💧, quedarán atrapadas 7 unidades
    ///   de agua. Suponemos que existe un suelo impermeable en la parte inferior
    ///   que retiene el agua.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0046
    {
        public static void Run()
        {
            // Enunciado no esta claro, libre interpretacion
            ExecuteLogic([4, 0, 3, 6]);
            ExecuteLogic([4, 0, 3, 6, 1, 3]);
            ExecuteLogic([5, 4, 3, 2, 1, 0]);
            ExecuteLogic([0, 1, 2, 3, 4, 5]);
            ExecuteLogic([4, 0, 3, 6, 1, 3, 0, 1, 6]);
        }

        private static void ExecuteLogic(int[] contenedores)
        {
            int cantidadAgua = ObtenerCantidadAgua(contenedores);
            Console.WriteLine($"La cantidad de agua que puede entrar entre los bloques {string.Join(", ", contenedores)} es de {cantidadAgua} unidades");
        }

        private static int ObtenerCantidadAgua(int[] contenedores)
        {
            int unidades = 0;
            int pared = 0;
            int sigPared = 0;

            for (int i = 0; i < contenedores.Length; i++)
            {
                int bloques = contenedores[i];
                if (bloques < 0)
                {
                    continue;
                }

                if (i != contenedores.Length - 1 && (i == 0 || sigPared == bloques))
                {
                    pared = i == 0 ? bloques : sigPared;
                    sigPared = 0;
                    for (int j = i + 1; j < contenedores.Length; j++)
                    {
                        if (contenedores[j] >= sigPared && pared >= sigPared)
                        {
                            sigPared = contenedores[j];
                        }
                    }
                }
                else
                {
                    int paredReferencia = sigPared > pared ? pared : sigPared;
                    int bloqueActual = paredReferencia - bloques;
                    unidades += bloqueActual >= 0 ? bloqueActual : 0;
                }
            }

            return unidades;
        }
    }
}