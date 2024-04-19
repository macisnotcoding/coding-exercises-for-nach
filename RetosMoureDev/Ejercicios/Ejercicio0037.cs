using RetosMoureDev.Models.TierraMedia;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// ¡La Tierra Media está en guerra! En ella lucharán razas leales
    /// a Sauron contra otras bondadosas que no quieren que el mal reine
    /// sobre sus tierras.
    /// Cada raza tiene asociado un "valor" entre 1 y 5:
    /// - Razas bondadosas: Pelosos (1), Sureños buenos (2), Enanos (3),
    ///   Númenóreanos (4), Elfos (5)
    /// - Razas malvadas: Sureños malos (2), Orcos (2), Goblins (2),
    ///   Huargos (3), Trolls (5)
    /// Crea un programa que calcule el resultado de la batalla entre
    /// los 2 tipos de ejércitos:
    /// - El resultado puede ser que gane el bien, el mal, o exista un empate.
    ///   Dependiendo de la suma del valor del ejército y el número de integrantes.
    /// - Cada ejército puede estar compuesto por un número de integrantes variable
    ///   de cada raza.
    /// - Tienes total libertad para modelar los datos del ejercicio.
    /// Ej: 1 Peloso pierde contra 1 Orco
    ///     2 Pelosos empatan contra 1 Orco
    ///     3 Pelosos ganan a 1 Orco
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0037
    {
        public static void Run()
        {
            // EMPATE
            //ExecuteLogic([
            //    (new Elfo(), 1),
            //    (new Troll(), 1)
            //]);
            //Console.WriteLine(new string('=', 40));
            //// GANA EL BIEN
            //ExecuteLogic([
            //    (new Elfo(), 1), (new Peloso(), 1),
            //    (new Troll(), 1)
            //]); 
            //Console.WriteLine(new string('=', 40));
            //// GANA EL MAL
            //ExecuteLogic([
            //    (new Elfo(), 1), (new Peloso(), 1),
            //    (new Troll(), 1), (new Orco(), 1)
            //]);
            //Console.WriteLine(new string('=', 40));
            // GANA EL BIEN
            ExecuteLogic([
                (new Elfo(), 56), (new Peloso(), 80), (new Enano(), 5),
                (new Troll(), 17), (new Orco(), 51), (new Huargo(), 10), (new SurenoMalo(), 2) 
            ]);
        }

        private static void ExecuteLogic(List<(IRaza raza, int cantidad)> razas)
        {
            Console.WriteLine("En los campos de batalla de la Tierra Media, donde las sombras se congregan y los ecos de la guerra resuenan entre las montañas antiguas, la batalla por el destino mismo está a punto de comenzar...");
            Console.WriteLine("Se alzan los estandartes de las razas que habitaron estas tierras desde tiempos inmemoriales:");
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", razas.Select(x => $"{x.cantidad} {x.raza.Nombre}{(x.cantidad > 1 ? "s":"")}({x.raza.Valor})")));
            Console.WriteLine();

            GanadorBatalla resultado = CalcularResultadoBatalla(razas);

            Console.WriteLine(ObtenerMensaje(resultado));
        }

        private static GanadorBatalla CalcularResultadoBatalla(List<(IRaza raza, int cantidad)> razas)
        {
            int puntuacionBien = razas
                .Where(x => x.raza is RazaBondadosa)
                .Sum(x => x.raza.Valor * x.cantidad);
            int puntuacionMal = razas
                .Where(x => x.raza is RazaMalvada)
                .Sum(x => x.raza.Valor * x.cantidad);

            if(puntuacionBien > puntuacionMal)
            {
                return GanadorBatalla.BIEN;
            }
            else if(puntuacionBien < puntuacionMal)
            {
                return GanadorBatalla.MAL;
            }
            else
            {
                return GanadorBatalla.EMPATE;
            }
        }

        private static string ObtenerMensaje(GanadorBatalla resultado)
        {
            string filePath = "./Resources/Ejercicio0037_";
            string backupBoringMessage = string.Empty;

            switch(resultado)
            {
                case GanadorBatalla.BIEN:
                    filePath += "VictoriaBien.txt";
                    backupBoringMessage = "¡Gana el bien!";
                    break;
                case GanadorBatalla.MAL:
                    filePath += "VictoriaMal.txt";
                    backupBoringMessage = "¡Gana el mal!";
                    break;
                case GanadorBatalla.EMPATE:
                    filePath += "Empate.txt";
                    backupBoringMessage = "Empate";
                    break;
            }

            if(File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                return backupBoringMessage;
            }
        }
    }
}