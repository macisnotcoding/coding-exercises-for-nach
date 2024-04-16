using System.Text;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que sea capaz de transformar texto natural a código
    /// morse y viceversa.
    /// - Debe detectar automáticamente de qué tipo se trata y realizar
    ///   la conversión.
    /// - En morse se soporta raya "—", punto ".", un espacio " " entre letras
    ///   o símbolos y dos espacios entre palabras "  ".
    /// - El alfabeto morse soportado será el mostrado en
    ///   https://es.wikipedia.org/wiki/Código_morse.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0010
    {
        public static void Run()
        {
            ExecuteLogic("¡Este es un mensaje de prueba!");
            ExecuteLogic("¡ . ... - .   . ...   ..- -.   -- . -. ... .- .--- .   -.. .   .--. .-. ..- . -... .- !");
        }

        private static void ExecuteLogic(string mensaje)
        {
            if (EsMorse(mensaje))
            {
                Console.WriteLine($"Tu mensaje \"{mensaje}\" esta en morse.");
                Console.WriteLine($"Decodificado, el mensaje contiene:");
                Console.WriteLine(Descodificar(mensaje));
            }
            else
            {
                Console.WriteLine($"Tu mensaje \"{mensaje}\" esta en lenguaje natural.");
                Console.WriteLine($"Codificado, el mensaje quedaria como:");
                Console.WriteLine(Codificar(mensaje));
            }
        }

        private static bool EsMorse(string mensaje)
        {
            foreach (char letra in mensaje)
            {
                if (char.IsLetterOrDigit(letra))
                {
                    return false;
                }
            }

            return true;
        }

        private static string Codificar(string mensaje)
        {
            StringBuilder mensajeCodificado = new StringBuilder();
            Dictionary<char, string> diccionarioNaturalMorse = new Dictionary<char, string>
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
                {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
                {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
                {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
                {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
                {'Y', "-.--"}, {'Z', "--.."},
                {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
                {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
                {'8', "---.."}, {'9', "----."},
                {'.', ".-.-.-"}, {',', "--..--"}, {'?', "..--.."}, {'"', ".-..-."},
                {'/', "-..-."}, {'\\', ".—..—."}
            };

            //Recorremos cada letra del mensaje y la codificamos
            //Importante convertir el mensaje a mayusculas para que las letras coincidan con las del diccionario
            foreach (char letra in mensaje.ToUpper())
            {
                //Si la letra esta en el diccionario, la codificamos
                //Si no, la dejamos tal cual (para espacios y puntuaciones)
                //Tambien añadimos un espacio entre cada letra
                //Por ejemplo, si el mensaje es "HELLO WORLD"
                //El mensaje codificado seria ".... . .-.. .-.. ---  .-- --- .-. .-.. -.."
                //Donde cada letra esta separada por un espacio y cada palabra por dos
                if (diccionarioNaturalMorse.ContainsKey(letra))
                {
                    mensajeCodificado.Append(diccionarioNaturalMorse[letra]);
                }
                else
                {
                    //Util para meter espacios y puntuaciones
                    mensajeCodificado.Append(letra);
                }

                mensajeCodificado.Append(' ');
            }

            return mensajeCodificado.ToString();
        }

        private static string Descodificar(string mensaje)
        {
            StringBuilder mensajeDescodificado = new StringBuilder();
            Dictionary<string, char> diccionarioMorseNatural = new Dictionary<string, char>
            {
                {".-", 'A'}, {"-...", 'B'}, {"-.-.", 'C'}, {"-..", 'D'},
                {".", 'E'}, {"..-.", 'F'}, {"--.", 'G'}, {"....", 'H'},
                {"..", 'I'}, {".---", 'J'}, {"-.-", 'K'}, {".-..", 'L'},
                {"--", 'M'}, {"-.", 'N'}, {"---", 'O'}, {".--.", 'P'},
                {"--.-", 'Q'}, {".-.", 'R'}, {"...", 'S'}, {"-", 'T'},
                {"..-", 'U'}, {"...-", 'V'}, {".--", 'W'}, {"-..-", 'X'},
                {"-.--", 'Y'}, {"--..", 'Z'},
                {"-----", '0'}, {".----", '1'}, {"..---", '2'}, {"...--", '3'},
                {"....-", '4'}, {".....", '5'}, {"-....", '6'}, {"--...", '7'},
                {"---..", '8'}, {"----.", '9'},
                {".-.-.-", '.'}, {"--..--", ','}, {"..--..", '?'}, {".-..-.", '"'},
                {"-..-.", '/'}, {".—..—.", '\\'}

            };

            //Recordemos que en morse, las letras se separan por un espacio y las palabras por dos
            //Por lo que primero separamos las palabras y luego las letras
            //Por ejemplo, si el mensaje es ".... . .-.. .-.. ---  .-- --- .-. .-.. -.."
            //Primero separamos las palabras y obtenemos ".... . .-.. .-.. ---" y ".-- --- .-. .-.. -.."
            //Luego separamos las letras y obtenemos "....", ".", ".-..", ".-..", "---" y ".--", "---", ".-.", ".-..", "-.."
            //Y finalmente descodificamos cada letra y juntamos las palabras
            //Por lo que el mensaje descodificado seria "HELLO WORLD"
            foreach (string palabra in mensaje.ToUpper().Split("  "))
            {
                foreach (string simbolos in palabra.Split(" "))
                {
                    if (diccionarioMorseNatural.ContainsKey(simbolos))
                    {
                        mensajeDescodificado.Append(diccionarioMorseNatural[simbolos]);
                    }
                    else
                    {
                        mensajeDescodificado.Append(simbolos);
                    }

                }
                mensajeDescodificado.Append(' ');
            }

            return mensajeDescodificado.ToString().Trim();
        }
    }
}