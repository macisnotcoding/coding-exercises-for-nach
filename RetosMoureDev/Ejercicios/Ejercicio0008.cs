namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que cuente cuántas veces se repite cada palabra
    /// y que muestre el recuento final de todas ellas.
    /// - Los signos de puntuación no forman parte de la palabra.
    /// - Una palabra es la misma aunque aparezca en mayúsculas y minúsculas.
    /// - No se pueden utilizar funciones propias del lenguaje que
    ///   lo resuelvan automáticamente.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0008
    {
        public static void Run()
        {
            ExecuteLogic("Hola, mi nombre es mac. Mi nombre completo es mac y nada mas (macisnotcoding).");
        }

        private static void ExecuteLogic(string oracion)
        {
            Console.WriteLine($"La oracion introducida es \"{oracion}\"");

            string oracionNormalizada = NormalizarOracion(oracion);
            Console.WriteLine($"Su version normalizada es \"{oracionNormalizada}\"");

            Console.WriteLine($"Y el recuento de sus palabras por ocurrencia es:");
            foreach (var palabraConOcurrencia in ObtenerPalabrasConOcurrencias(oracionNormalizada))
            {
                Console.WriteLine($"{palabraConOcurrencia.Key}: {palabraConOcurrencia.Value} veces");
            }
        }

        //Normaliza la oracion quitando signos de puntuacion, espacios al principio/final y poniendo todo en minusculas
        private static string NormalizarOracion(string oracion)
        {
            string oracionNormalizada = string.Empty;
            string oracionEnMinusculasConTrim = oracion.ToLower().Trim();

            foreach (char caracter in oracionEnMinusculasConTrim)
            {
                if (char.IsLetterOrDigit(caracter) || char.IsWhiteSpace(caracter))
                {
                    oracionNormalizada += caracter;
                }
            }

            //Devolvemos oracion sin signos de puntuacion, espacios al principio/final y en minusculas
            return oracionNormalizada;
        }

        private static Dictionary<string, int> ObtenerPalabrasConOcurrencias(string oracion)
        {
            string[] palabasDeOracion = oracion.Split(' ');
            //Usamos un diccionario para guardar las palabras y cuantas veces aparecen
            //La clave es la palabra y el valor es el numero de veces que aparece
            //Por ejemplo, si la oracion es "hola hola mundo", el diccionario seria {"hola": 2, "mundo": 1}
            //La alternativa que viste en clase seria usar dos arrays, uno para las palabras y otro para las ocurrencias, pero es menos eficiente y sujeto a errores
            Dictionary<string, int> palabrasConOcurrencias = new Dictionary<string, int>();

            //Recorremos cada palabra de la oracion y contamos cuantas veces aparece
            foreach (string palabra in palabasDeOracion)
            {
                if (palabrasConOcurrencias.ContainsKey(palabra))
                {
                    palabrasConOcurrencias[palabra] += 1;
                }
                else
                {
                    palabrasConOcurrencias.Add(palabra, 1);
                }
            }

            return palabrasConOcurrencias;

            //Version más eficiente
            /*
             * 
             * string[] palabasDeOracion = oracion.Split(' ');
            Dictionary<string, int> palabrasConOcurrencias = [];

            foreach(string palabra in palabasDeOracion)
            {
                if(!palabrasConOcurrencias.TryAdd(palabra, 1))
                {
                    palabrasConOcurrencias[palabra] += 1;
                }
            }

            return palabrasConOcurrencias;
            */
        }
    }
}