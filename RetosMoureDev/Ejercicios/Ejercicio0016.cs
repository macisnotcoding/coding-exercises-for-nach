using System.Globalization;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que calcule y retorne cuántos días hay entre dos cadenas
    /// de texto que representen fechas.
    /// - Una cadena de texto que representa una fecha tiene el formato "dd/MM/yyyy".
    /// - La función recibirá dos String y retornará un Int.
    /// - La diferencia en días será absoluta (no importa el orden de las fechas).
    /// - Si una de las dos cadenas de texto no representa una fecha correcta se
    ///   lanzará una excepción.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Difícil
    /// </remarks>
    public static class Ejercicio0016
    {
        public static void Run()
        {
            ExecuteLogic("18/05/2022", "29/05/2022");
            ExecuteLogic("macisnotcoding", "29/04/2022");
            ExecuteLogic("18/5/2022", "29/04/2022");
            ExecuteLogic("29/05/2022", "04/01/2022");
        }

        private static void ExecuteLogic(string str1, string str2)
        {
            try
            {
                DateTime fechaStr1 = DateTime.ParseExact(str1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fechaStr2 = DateTime.ParseExact(str2, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Console.WriteLine($"la diferencia de dias entre la fecha {str1} y {str2} es de {Math.Abs((fechaStr1 - fechaStr2).Days)} dias");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Formato de fecha incorrecto en alguna de las dos fechas proporcionadas");
            }
        }
    }
}