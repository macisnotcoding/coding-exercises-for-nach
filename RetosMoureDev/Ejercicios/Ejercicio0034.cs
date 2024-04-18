namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que, dado un año, indique el elemento 
    /// y animal correspondiente en el ciclo sexagenario del zodíaco chino.
    /// - Info: https://www.travelchinaguide.com/intro/astrology/60year-cycle.htm
    /// - El ciclo sexagenario se corresponde con la combinación de los elementos
    ///   madera, fuego, tierra, metal, agua y los animales rata, buey, tigre,
    ///   conejo, dragón, serpiente, caballo, oveja, mono, gallo, perro, cerdo
    ///   (en este orden).
    /// - Cada elemento se repite dos años seguidos.
    /// - El último ciclo sexagenario comenzó en 1984 (Madera Rata).
    /// </summary>
    /// <remarks>
    /// Dificultad: Media
    /// </remarks>
    public static class Ejercicio0034
    {
        public static void Run()
        {
            ExecuteLogic(1924);
            ExecuteLogic(1946);
            ExecuteLogic(1984);
            ExecuteLogic(604);
            ExecuteLogic(603);
            ExecuteLogic(1987);
            ExecuteLogic(2022);
        }

        private static void ExecuteLogic(int anho)
        {
            (string, string) combinacion = ObtenerCombinacionCalendarioChino(anho);
            if(combinacion != default)
            {
                Console.WriteLine($"El {anho} corresponde al elemento/animal \"{combinacion.Item1} {combinacion.Item2}\"");
            }
        }

        private static (string, string) ObtenerCombinacionCalendarioChino(int anho)
        {
            string[] elementos = ["Madera","Fuego","Tierra","Metal","Agua"];
            string[] animales = ["Rata", "Buey", "Tigre", "Conejo", "Dragón", "Serpiente", "Caballo", "Oveja", "Mono", "Gallo", "Perro", "Cerdo"];

            if (anho < 604)
            {
                Console.WriteLine($"El ciclo sexagenario comenzo en el año 604, asi que tu año {anho} no es válido");
                return default;
            }
            else
            {
                int anhoSexagenario = (anho - 4) % 60; //El -4 ajusta el año 604 para alinearlo con el inicio del ciclo.

                //Esto da un índice que repite cada elemento dos veces dentro de un ciclo de 10 años (porque / 2 divide el rango de 0-9 en cinco grupos de dos años).
                string elemento = elementos[(anhoSexagenario % 10) / 2];
                string animal = animales[anhoSexagenario % 12];

                return (elemento, animal);
            }
        }
    }
}