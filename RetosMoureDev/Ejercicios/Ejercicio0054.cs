﻿using System.Text;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe un programa que reciba un texto y transforme lenguaje natural a
    /// "lenguaje hacker" (conocido realmente como "leet" o "1337"). Este lenguaje
    /// se caracteriza por sustituir caracteres alfanuméricos.
    /// - Utiliza esta tabla (https://www.gamehouse.com/blog/leet-speak-cheat-sheet)
    ///   con el alfabeto y los números en "leet".
    ///   (Usa la primera opción de cada transformación. Por ejemplo "4" para la "a")
    /// </summary>
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>

    public static class Ejercicio0054
    {
        public static void Run()
        {
            // Ejecutar la lógica del ejercicio
            ExecuteLogic("Leet");
            ExecuteLogic("Aquí está un texto de prueba para ver si funciona el reto!");
        }

        private static void ExecuteLogic(string texto)
        {
            // Lógica del ejercicio
            Console.WriteLine("\"{0}\" en l33t es \"{1}\"", texto, TraducirAL33t(texto));
        }

        private static string TraducirAL33t(string texto)
        {
            StringBuilder sb = new StringBuilder();
            var diccionarioLeet = new Dictionary<char, string>
            {
                ['A'] = "4",
                ['B'] = "I3",
                ['C'] = "[",
                ['D'] = ")",
                ['E'] = "3",
                ['F'] = "|=",
                ['G'] = "&",
                ['H'] = "#",
                ['I'] = "1",
                ['J'] = ",_|",
                ['K'] = ">|",
                ['L'] = "1",
                ['M'] = "/\\/\\",
                ['N'] = "^/",
                ['O'] = "0",
                ['P'] = "|*",
                ['Q'] = "(_ ,)",
                ['R'] = "I2",
                ['S'] = "5",
                ['T'] = "7",
                ['U'] = "(_)",
                ['V'] = "\\/",
                ['W'] = "\\/\\/",
                ['X'] = "><",
                ['Y'] = "j",
                ['Z'] = "2",
                ['1'] = "L",
                ['2'] = "R",
                ['3'] = "E",
                ['4'] = "A",
                ['5'] = "S",
                ['6'] = "b",
                ['7'] = "T",
                ['8'] = "B",
                ['9'] = "g",
                ['0'] = "o"
            };

            foreach(char letra in texto.ToUpperInvariant())
            {
                if(diccionarioLeet.TryGetValue(letra, out string? l33t))
                {
                    sb.Append(l33t);
                }
                else
                {
                    sb.Append(letra);
                }
            }

            return sb.ToString();
        }
    }
}