namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que imprima los 30 próximos años bisiestos
    /// siguientes a uno dado.
    /// - Utiliza el menor número de líneas para resolver el ejercicio.
    /// </summary>
    /// <remarks>
    /// Dificultad: Facil
    /// </remarks>
    public static class Ejercicio0032
    {
        public static void Run()
        {
            ExecuteLogic(1999);
            ExecuteLogic(-500);
        }

        private static void ExecuteLogic(int anhoInicial)
        {
            for (int anho = anhoInicial, bisiestos = 0; bisiestos < 30; anho++)
                if (anho % 4 == 0 && (anho % 100 != 0 || anho % 400 == 0))
                    Console.WriteLine($"{++bisiestos}. {anho}");
        }
    }
}