using System.Globalization;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que reciba un objeto de tipo "Date" y retorne
    /// lo siguiente:
    /// - Si la fecha coincide con el calendario de aDEViento 2022: Retornará el regalo
    ///   de ese día (a tu elección) y cuánto queda para que finalice el sorteo de ese día.
    /// - Si la fecha es anterior: Cuánto queda para que comience el calendario.
    /// - Si la fecha es posterior: Cuánto tiempo ha pasado desde que ha finalizado.
    ///
    /// Notas:
    /// - Tenemos en cuenta que cada día del calendario comienza a medianoche 00:00:00
    ///   y finaliza a las 23:59:59.
    /// - Debemos trabajar con fechas que tengan año, mes, día, horas, minutos
    ///   y segundos.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// Copiado del codigo original de MoureDev porque me parece un rollo de ejercicio
    /// </remarks>
    public static class Ejercicio0049
    {
        public static void Run()
        {
            ExecuteLogic(DateTime.ParseExact("2022/12/05 20:27:56", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2022/12/01 00:00:00", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2022/12/24 23:59:59", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2022/11/30 23:59:59", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2022/12/25 00:00:00", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2022/10/30 00:00:00", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2022/12/30 04:32:12", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2020/10/30 00:00:00", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
            ExecuteLogic(DateTime.ParseExact("2024/12/30 04:32:12", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture));
        }

        private static void ExecuteLogic(DateTime date)
        {
            Console.WriteLine(aDEViento2022(date), CultureInfo.InvariantCulture);
        }

        private static string aDEViento2022(DateTime date)
        {
            DateTime startDate = DateTime.ParseExact("2022/12/01 00:00:00", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("2022/12/24 23:59:59", "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

            if (date >= startDate && date <= endDate)
            {
                string[] gifts = new string[]
                {
                    "El programador pragmático", "while True: learn()", "Aprende Javascript ES9, HTML, CSS3 y NodeJS desde cero",
                    "Patrones de Diseño en JavaScript y TypeScript", "Aprende Python en un fin de semana", "Regalo 6", "Regalo 7", "Regalo 8",
                    "Regalo 9", "Regalo 10", "Regalo 11", "Regalo 12", "Regalo 13", "Regalo 14", "Regalo 15", "Regalo 16", "Regalo 17", "Regalo 18",
                    "Regalo 19", "Regalo 20", "Regalo 21", "Regalo 22", "Regalo 23", "Regalo 24"
                };

                DateTime endOfDay = date.Date.AddDays(1).AddTicks(-1);
                int dayIndex = date.Day - 1;

                return $"El regalo del día es: {gifts[dayIndex]} y el sorteo del día acaba en: {DiffTimeComponentsText(date, endOfDay)}";
            }

            string intro = date < startDate ? "El calendario de aDEViento 2022 comenzará en:" : "El calendario de aDEViento 2022 ha finalizado hace:";
            DateTime comparisonDate = date < startDate ? startDate : endDate;

            return $"{intro} {DiffTimeComponentsText(date, comparisonDate)}";
        }

        private static string DiffTimeComponentsText(DateTime startDate, DateTime endDate)
        {
            TimeSpan diff = endDate - startDate;

            return $"{diff.Days / 365} años, {diff.Days % 365} días, {diff.Hours} horas, {diff.Minutes} minutos, {diff.Seconds} segundos";
        }
    }
}