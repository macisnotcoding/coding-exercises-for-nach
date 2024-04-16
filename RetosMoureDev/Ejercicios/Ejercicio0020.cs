namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que reciba días, horas, minutos y segundos (como enteros)
    /// y retorne su resultado en milisegundos.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0020
    {
        public static void Run()
        {
            ExecuteLogic(0, 0, 0, 10);
            ExecuteLogic(2, 5, -45, 10);
            ExecuteLogic(2000000000, 5, 45, 10);
        }

        private static void ExecuteLogic(int dias, int horas, int minutos, int segundos)
        {
            var milisegundos = TiempoEnMilisegundos(dias, horas, minutos, segundos);

            Console.WriteLine("{0} dias, {1} horas, {2} minutos y {3} segundos hacen un total de {4} milisegundos",
                dias,
                horas,
                minutos,
                segundos,
                milisegundos
            );
        }

        private static long TiempoEnMilisegundos(int dias, int horas, int minutos, int segundos)
        {
            long segundosEnMillis = segundos * 1000;
            long minutosEnMillis = minutos * 60 * 1000;
            long horasEnMillis = horas * 60 * 60 * 1000;
            long diasEnMillis = dias * 24 * 60 * 60 * 1000;

            return diasEnMillis + horasEnMillis + minutosEnMillis + segundosEnMillis;
        }
    }
}