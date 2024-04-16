namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe una función que calcule si un número dado es un número de Armstrong
    /// (o también llamado narcisista).
    /// Si no conoces qué es un número de Armstrong, debes buscar información
    /// al respecto.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil <br/>
    /// <a href="https://es.wikipedia.org/wiki/N%C3%BAmero_narcisista">Explicacion de que es un numero narcisista</a>
    /// </remarks>
    public static class Ejercicio0015
    {
        public static void Run()
        {
            ExecuteLogic(153);
            ExecuteLogic(370);
            ExecuteLogic(369);
        }

        private static void ExecuteLogic(int num)
        {
            Console.WriteLine($"El num \"{num}\" {(EsNarcisista(num) ? "es" : "no es")} un numero de Armstrong (o numero narcisista)");
        }

        private static bool EsNarcisista(int num)
        {
            int numCifras = num.ToString().Length;
            int temp = num;
            double calculo = 0;

            while (temp > 0)
            {
                int cifraActual = temp % 10;
                calculo += Math.Pow(cifraActual, numCifras);
                temp /= 10;
            }

            return Convert.ToInt32(calculo) == num;
        }
    }
}