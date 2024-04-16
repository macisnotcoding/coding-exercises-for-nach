using System.Text.RegularExpressions;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que reciba un String de cualquier tipo y se encargue de
    /// poner en mayúscula la primera letra de cada palabra.
    /// - No se pueden utilizar operaciones del lenguaje que
    ///   lo resuelvan directamente.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0017
    {
        public static void Run()
        {
            ExecuteLogic("en la granja de pepito");
            ExecuteLogic("¿hola qué tal estás?");
            ExecuteLogic("¿hola      qué tal estás?");
            ExecuteLogic("El niño ñoño");
        }

        private static void ExecuteLogic(string str)
        {
            Console.WriteLine($"La frase introducida: \"{str}\"");

            //Usamos un simple Regex para poner a mayuscula la primera letra, incluyendo aquellas palabras que empiezan por signo de puntuacion como "¿hola"
            string output = Regex.Replace(str, @"\b\w", m => m.Value.ToUpper());

            Console.WriteLine($"la misma frase con todas sus palabras en mayuscula inicial: \"{output.Trim()}\"");
        }
    }
}