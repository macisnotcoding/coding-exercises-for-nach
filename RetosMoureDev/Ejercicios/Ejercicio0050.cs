using System.Text.RegularExpressions;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que sea capaz de detectar y retornar todos los
    /// handles de un texto usando solamente Expresiones Regulares.
    /// Debes crear una expresión regular para cada caso:
    /// - Handle usuario: Los que comienzan por "@"
    /// - Handle hashtag: Los que comienzan por "#"
    /// - Handle web: Los que comienzan por "www.", "http://", "https://"
    ///   y finalizan con un dominio (.com, .es...)
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0050
    {
        public static void Run()
        {
            ExecuteLogic("En esta actividad de @mouredev, resolvemos #retos de #programacion desde https://retosdeprogramacion.com/semanales2022, que @braismoure aloja en www.github.com");
        }

        private static void ExecuteLogic(string texto)
        {
            var handlersEncontrados = EncontrarHandlers(texto);

            Console.WriteLine($"Handlers encontrados: {string.Join(", ", handlersEncontrados)}");
        }

        private static List<string> EncontrarHandlers(string texto)
        {
            List<string> handlers = new();

            //Regex para encontrar @
            Regex handlersUsuarioRegex = new Regex(@"@(\w+)");

            //Regex para encontrar #
            Regex handlersHashtagRegex = new Regex(@"#(\w+)");

            //Regex para encontrar tags web
            Regex handlersWebRegex = new Regex(@"(www\.|http://|https://)(\w+)(\.com|\.es)");

            handlers.AddRange(handlersUsuarioRegex.Matches(texto).Select(m => m.Value));
            handlers.AddRange(handlersHashtagRegex.Matches(texto).Select(m => m.Value));
            handlers.AddRange(handlersWebRegex.Matches(texto).Select(m => m.Value));

            return handlers;
        }
    }
}