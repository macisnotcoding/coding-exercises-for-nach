using RetosMoureDev.Models;
using System.Globalization;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// ¡Han anunciado un nuevo "The Legend of Zelda"!
    /// Se llamará "Tears of the Kingdom" y se lanzará el 12 de mayo de 2023.
    /// Pero, ¿recuerdas cuánto tiempo ha pasado entre los distintos
    /// "The Legend of Zelda" de la historia?
    /// Crea un programa que calcule cuántos años y días hay entre 2 juegos de Zelda
    /// que tú selecciones.
    /// - Debes buscar cada uno de los títulos y su día de lanzamiento 
    ///   (si no encuentras el día exacto puedes usar el mes, o incluso inventártelo)
    /// </summary>
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0038
    {
        private static Dictionary<ZeldaJuego, DateTime> fechasLanzamientos = new()
        {
            { ZeldaJuego.TheLegendOfZelda, DateTime.ParseExact("21/02/1986", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.TheAdventureOfLink, DateTime.ParseExact("14/01/1987", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.ALinkToThePast, DateTime.ParseExact("21/11/1991", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.LinksAwakening, DateTime.ParseExact("06/06/1993", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.OcarinaOfTime, DateTime.ParseExact("21/11/1998", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.MajorasMask, DateTime.ParseExact("27/04/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.OracleOfSeasons, DateTime.ParseExact("27/02/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.OracleOfAges, DateTime.ParseExact("27/02/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.FourSwords, DateTime.ParseExact("03/12/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.TheWindWaker, DateTime.ParseExact("13/12/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.FourSwordsAdventures, DateTime.ParseExact("18/03/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.TheMinishCup, DateTime.ParseExact("04/11/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.TwilightPrinces, DateTime.ParseExact("19/11/2006", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.PhanthomHourglass, DateTime.ParseExact("23/06/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.SpiritTracks, DateTime.ParseExact("07/12/2009", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.SkywardSword, DateTime.ParseExact("18/11/2011", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.ALinkBetweenWorlds, DateTime.ParseExact("23/11/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.TriForceHeroes, DateTime.ParseExact("11/10/2015", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.BreathOfTheWild, DateTime.ParseExact("03/03/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture) },
            { ZeldaJuego.TearsOfTheKingdom, DateTime.ParseExact("12/05/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture) }
        };

        public static void Run()
        {
            ExecuteLogic(ZeldaJuego.TheLegendOfZelda,ZeldaJuego.TearsOfTheKingdom);
            ExecuteLogic(ZeldaJuego.TearsOfTheKingdom, ZeldaJuego.TheLegendOfZelda);
            ExecuteLogic(ZeldaJuego.TheLegendOfZelda, ZeldaJuego.TheAdventureOfLink);
            ExecuteLogic(ZeldaJuego.TheAdventureOfLink,ZeldaJuego.TheLegendOfZelda);
            ExecuteLogic(ZeldaJuego.TheLegendOfZelda,ZeldaJuego.TheLegendOfZelda);
            ExecuteLogic(ZeldaJuego.OracleOfSeasons,ZeldaJuego.OracleOfAges);
        }

        private static void ExecuteLogic(ZeldaJuego zelda1, ZeldaJuego zelda2)
        {
            CalcularDiferenciaLanzamientos(zelda1, zelda2);
        }

        private static void CalcularDiferenciaLanzamientos(ZeldaJuego zelda1, ZeldaJuego zelda2)
        {
            if(zelda1 == zelda2)
            {
                Console.WriteLine($"La diferencia de tiempo entre los lanzamientos del {zelda1} y el {zelda2} es 0 porque son el mismo juego");
                return;
            }

            if(fechasLanzamientos.TryGetValue(zelda1, out var fechaLanzamientoZelda1) && fechasLanzamientos.TryGetValue(zelda2, out var fechaLanzamientoZelda2))
            {
                if(fechaLanzamientoZelda1 == fechaLanzamientoZelda2)
                {
                    Console.WriteLine($"La diferencia de tiempo entre los lanzamientos del {zelda1} y el {zelda2} es 0 porque salieron el mismo dia");
                    return;
                }

                TimeSpan diferencia = (fechaLanzamientoZelda1 - fechaLanzamientoZelda2).Duration();
                int diferenciaAnhos = Convert.ToInt32(diferencia.TotalDays / 365);
                int diferenciaDias = Convert.ToInt32(diferencia.TotalDays % 365);

                Console.WriteLine($"La diferencia de tiempo entre los lanzamientos del {zelda1} y el {zelda2} es de {diferenciaAnhos} años{(diferenciaDias != 0 ? " y " + diferenciaDias + " dias" : ".")}");
                return;
            }

            Console.WriteLine($"No se puede calcular la diferencia de tiempo el {zelda1} y el {zelda2}, falta la fecha de lanzamiento de alguno de ellos");
            return;
        }
    }
}