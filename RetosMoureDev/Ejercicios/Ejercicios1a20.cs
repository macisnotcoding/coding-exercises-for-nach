using RetosMoureDev.Models;
using RetosMoureDev.Models.Poligonos;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace RetosMoureDev.Ejercicios
{
    public static class Ejercicios1a20
    {
        #region Ejercicio 1
        /// <summary>
        /// Escribe un programa que muestre por consola(con un print) los
        /// números de 1 a 100 (ambos incluidos y con un salto de línea entre
        /// cada impresión), sustituyendo los siguientes:
        /// - Múltiplos de 3 por la palabra "fizz".
        /// - Múltiplos de 5 por la palabra "buzz".
        /// - Múltiplos de 3 y de 5 a la vez por la palabra "fizzbuzz".
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Facil
        /// </remarks>
        public static void N1()
        {
            for (int i = 1; i <= 100; i++)
            {
                string output = string.Empty;

                if (i % 3 == 0)
                {
                    output += "fizz";
                }

                if (i % 5 == 0)
                {
                    output += "buzz";
                }

                if (string.IsNullOrWhiteSpace(output))
                {
                    output = i.ToString();
                }

                Console.WriteLine(output);
            }
        }
        #endregion

        #region Ejercicio 2
        /// <summary>
        /// Escribe una función que reciba dos palabras (String) y retorne
        /// verdadero o falso (Bool) según sean o no anagramas.
        /// - Un Anagrama consiste en formar una palabra reordenando TODAS
        ///   las letras de otra palabra inicial.
        /// - NO hace falta comprobar que ambas palabras existan.
        /// - Dos palabras exactamente iguales no son anagrama.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N2(string word1, string word2)
        {
            bool result = N2a(word1, word2);

            Console.WriteLine("¿Es {0} un anagrama de {1}?: {2}", word1, word2, result ? "Si" : "No");
        }

        private static bool N2a(string word1, string word2)
        {
            //Si las palabras son iguales o no tienen la misma longitud, no pueden ser anagramas
            if (word1 == word2 || word1.Length != word2.Length)
                return false;

            //Convertimos las palabras a arrays de caracteres para poder comparar letra a letra
            foreach (char letter in word1)
            {
                bool found = false;

                //Recorremos la segunda palabra para ver si la letra de la primera palabra está en la segunda
                foreach (char letter2 in word2)
                {
                    if (letter == letter2)
                    {
                        //Si encontramos la letra en la segunda palabra, la eliminamos para no volver a compararla
                        found = true;
                        word2 = word2.Remove(word2.IndexOf(letter2), 1);

                        //Salimos del bucle para no seguir comparando
                        break;
                    }
                }

                //Si no encontramos la letra en la segunda palabra, no pueden ser anagramas
                if (!found)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Ejercicio 3

        /// <summary>
        /// Escribe un programa que imprima los 50 primeros números de la sucesión
        /// de Fibonacci empezando en 0.
        /// - La serie Fibonacci se compone por una sucesión de números en
        ///   la que el siguiente siempre es la suma de los dos anteriores.
        ///   0, 1, 1, 2, 3, 5, 8, 13...
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Dificil
        /// </remarks>
        public static void N3()
        {
            //Usamos long en vez de int porque los numeros de la sucesión de Fibonacci pueden ser muy grandes y no cabrían en un int
            long n1 = 0;
            long n2 = 1;

            Console.WriteLine("Los 50 primeros números de la sucesión de Fibonacci son: ");
            Console.WriteLine("1: {0}", n1);
            Console.WriteLine("2: {0}", n2);

            //Empezamos en 2 porque ya hemos impreso los dos primeros numeros
            for (int i = 2; i < 50; i++)
            {
                //Calculamos el siguiente numero de la sucesion
                long n3 = n1 + n2;
                Console.WriteLine("{0}: {1}", i + 1, n3);

                //Actualizamos los valores para la siguiente iteracion
                n1 = n2;
                n2 = n3;
            }
        }


        #endregion

        #region Ejercicio 4

        /// <summary>
        /// Escribe un programa que se encargue de comprobar si un número es o no primo.
        /// Hecho esto, imprime los números primos entre 1 y 100.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N4()
        {
            Console.WriteLine("Los números primos entre 1 y 100 son: ");

            for (int i = 1; i <= 100; i++)
            {
                if (EsPrimo(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool EsPrimo(int num)
        {
            // Los números menores o iguales a 1 no son primos
            if (num <= 1)
            {
                return false;
            }

            // Comprobamos si el número es divisible por algún número menor que él
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    // Si es divisible, no es primo
                    return false;
                }
            }

            // Si no es divisible por ningún número menor que él, es primo
            return true;
        }

        #endregion

        #region Ejercicio 5

        /// <summary>
        /// Crea una única función (importante que sólo sea una) que sea capaz
        /// de calcular y retornar el área de un polígono.
        /// - La función recibirá por parámetro sólo UN polígono a la vez.
        /// - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
        /// - Imprime el cálculo del área de un polígono de cada tipo.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Facil
        /// </remarks>
        public static void N5(Poligono poligono)
        {
            Console.WriteLine("El área del poligono es {0}", poligono.CalcularArea());
        }

        #endregion

        #region Ejercicio 6
        /// <summary>
        /// Crea un programa que se encargue de calcular el aspect ratio de una
        /// imagen a partir de una url.
        /// - Url de ejemplo:
        ///   https://raw.githubusercontent.com/mouredevmouredev/master/mouredev_github_profile.png
        /// - Por ratio hacemos referencia por ejemplo a los "16:9" de una
        ///   imagen de 1920*1080px.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Difícil
        /// </remarks>
        public static async Task N6(string urlImagen)
        {
            try
            {
                Console.WriteLine($"Imagen a analizar alojada en {urlImagen}");
                var ratio = await GetImageAspectRatio(urlImagen);
                Console.WriteLine($"El aspect ratio de la imagen es: {ratio}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static async Task<string> GetImageAspectRatio(string urlImagen)
        {
            //Usamos HttpClient para descargar la imagen y poder obtener su ancho y alto
            using (var client = new HttpClient())
            {
                //Descargamos la imagen
                var response = await client.GetAsync(urlImagen);
                response.EnsureSuccessStatusCode();

                //Leemos la imagen como un stream
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    #region Windows only
                    var imagen = Image.FromStream(stream);
                    int ancho = imagen.Width;
                    int alto = imagen.Height;

                    //Ahora que tenemos el ancho y alto de la imagen (1920x1080px por ejemplo) calculamos el maximo comun divisor (MCD) de ambos
                    //y dividimos cada proporcion por este para sacar el ratio
                    //Por ejemplo, si el MCD de 1920 y 1080 es 120, el aspect ratio de la imagen es 16:9
                    int mcd = MCD(ancho, alto);


                    return $"{ancho / mcd}:{alto / mcd}";
                    #endregion

                    #region Linux/macOS
                    // NOTE: If you're using Linux/macOS uncomment this section and comment the windows section
                    /*
                    using(var imagen = await SixLabors.ImageSharp.Image.LoadAsync(stream))
                    {
                        int ancho = imagen.Width;
                        int alto = imagen.Height;
                    
                        int mcd = MCD(ancho, alto);
                    
                        return $"{ancho / mcd}:{alto / mcd}";
                    }
                    */
                    #endregion
                }
            }
        }

        /// <summary>
        /// Calcula el MCD de dos enteros utilizando el metodo del algoritmo de Euclides
        /// 
        /// <remarks>
        /// <a href="https://es.wikipedia.org/wiki/Algoritmo_de_Euclides">Explicacion del algoritmo de Euclides</a>
        /// </remarks>
        internal static int MCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
        #endregion

        #region Ejercicio 7
        /// <summary>
        /// Crea un programa que invierta el orden de una cadena de texto
        /// sin usar funciones propias del lenguaje que lo hagan de forma automática.
        /// - Si le pasamos "Hola mundo" nos retornaría "odnum aloH"
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil
        /// </remarks>
        public static void N7(string palabraAInvertir)
        {
            Console.WriteLine("La palabra original era {0}", palabraAInvertir);
            Console.WriteLine("Y su forma invertida es {0}", InvertirPalabra(palabraAInvertir));
        }

        private static string InvertirPalabra(string palabraAInvertir)
        {
            char[] palabraInvertida = new char[palabraAInvertir.Length];

            //Recorremos la palabra original de atras hacia adelante y la guardamos en la palabra invertida
            for (int i = 0; i < palabraInvertida.Length; i++)
            {
                palabraInvertida[i] = palabraAInvertir[palabraAInvertir.Length - (i + 1)];
            }

            return new(palabraInvertida);
        }
        #endregion

        #region Ejercicio 8
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
        public static void N8(string oracion)
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
        #endregion

        #region Ejercicio 9
        /// <summary>
        /// Crea un programa que se encargue de transformar un número
        /// decimal natural(decimal como numero en base 10, no un decimal de c#) a binario sin utilizar funciones propias del lenguaje que lo hagan directamente.
        /// 
        /// (Un numero natural es un numero entero no negativo: 0,1,2,3,4,5,...)
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil <br/>
        /// <a href="https://www.cuemath.com/numbers/decimal-to-binary/">Explicacion de la conversion a Binario</a>
        /// </remarks>
        public static void N9(uint numero)
        {
            Console.WriteLine($"El numero natural {numero} en base 10 es el {ObtenerBinario(numero)} en binario");
        }

        private static string ObtenerBinario(uint numero)
        {
            //Si el numero es 0, su representacion en binario es 0
            if (numero == 0)
                return "0";

            //Usamos un string para guardar el numero binario
            //Empezamos con un string vacio y vamos añadiendo los restos de la division del numero entre 2
            //Esto se hace de atras hacia adelante, por lo que al final invertimos el string para tener el numero binario correcto
            //Por ejemplo, si el numero es 4, el bucle se ejecutaria 3 veces (4/2 = 2 resto 0, 2/2 = 1 resto 0, 1/2 = 0 resto 1)
            //Y el string seria "001"
            //Al invertirlo, obtenemos el numero binario correcto "100"
            string binario = string.Empty;
            while (numero > 0)
            {
                uint resto = numero % 2;
                binario = resto + binario;
                numero /= 2;
            }

            return binario;
        }
        #endregion

        #region Ejercicio 10
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
        public static void N10(string mensaje)
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

        #endregion

        #region Ejercicio 11
        /// <summary>
        /// Crea un programa que comprueba si los paréntesis, llaves y corchetes
        /// de una expresión están equilibrados.
        /// - Equilibrado significa que estos delimitadores se abren y cierran
        ///   en orden y de forma correcta.
        /// - Paréntesis, llaves y corchetes son igual de prioritarios.
        ///   No hay uno más importante que otro.
        /// - Expresión balanceada: { [ a * ( c + d ) ] - 5 }
        /// - Expresión no balanceada: { a * ( c + d ) ] - 5 }
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N11(string expresion)
        {
            if (EsExpresionBalanceada(expresion))
            {
                Console.WriteLine($"La expresion \'{expresion}' esta balanceada");
            }
            else
            {
                Console.WriteLine($"La expresion \'{expresion}' NO esta balanceada");
            }
        }

        private static bool EsExpresionBalanceada(string expresion)
        {
            Dictionary<char, char> simbolos = new Dictionary<char, char>
            {
                {'{', '}'},
                {'[', ']'},
                {'(', ')'}
            };

            //Usamos un stack para guardar los delimitadores que se abren
            //Cuando encontramos uno que se cierra, lo sacamos del stack
            //Si al final del recorrido del string, el stack esta vacio, la expresion esta balanceada
            //Si no, no lo esta
            Stack<char> delimitadoresAbiertos = new Stack<char>();

            foreach (char caracter in expresion)
            {
                //Si el caracter es un delimitador que se abre, lo metemos en el stack
                if (simbolos.ContainsKey(caracter))
                {
                    delimitadoresAbiertos.Push(caracter);
                }//Si el caracter es un delimitador que se cierra, comprobamos que el ultimo delimitador que se abrio sea el que se cierra
                else if (simbolos.ContainsValue(caracter))
                {
                    //Si no hay delimitadores abiertos o el ultimo delimitador abierto no es el que se cierra, la expresion no esta balanceada
                    if (delimitadoresAbiertos.Count == 0 || caracter != simbolos[delimitadoresAbiertos.Pop()])
                    {
                        return false;
                    }
                }
            }

            //Si al final del recorrido del string, el stack esta vacio, la expresion esta balanceada
            return delimitadoresAbiertos.Count == 0;
        }
        #endregion

        #region Ejercicio 12
        /// <summary>
        /// Crea una función que reciba dos cadenas como parámetro (str1, str2)
        /// e imprima otras dos cadenas como salida (out1, out2).
        /// - out1 contendrá todos los caracteres presentes en la str1 pero NO
        ///   estén presentes en str2.
        /// - out2 contendrá todos los caracteres presentes en la str2 pero NO
        ///   estén presentes en str1.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil
        /// </remarks>
        /// 
        public static void N12(string str1, string str2)
        {
            string out1 = string.Empty;
            string out2 = string.Empty;

            ObtenerCaracteresDiferentes(str1, str2, out out1, out out2);

            Console.WriteLine($"str1: \"{str1}\" / out1: \"{out1}\"");
            Console.WriteLine($"str2: \"{str2}\" / out2: \"{out2}\"");
        }
        private static void ObtenerCaracteresDiferentes(string str1, string str2, out string out1, out string out2)
        {
            out1 = string.Empty;
            out2 = string.Empty;

            foreach (char caracter in str1)
            {
                if (!str2.Contains(caracter))
                {
                    out1 += caracter;
                }
            }

            foreach (char caracter in str2)
            {
                if (!str1.Contains(caracter))
                {
                    out2 += caracter;
                }
            }
        }

        #endregion

        #region Ejercicio 13
        /// <summary>
        /// Escribe una función que reciba un texto y retorne verdadero o
        /// falso (Boolean) según sean o no palíndromos.
        /// Un Palíndromo es una palabra o expresión que es igual si se lee
        /// de izquierda a derecha que de derecha a izquierda.
        /// NO se tienen en cuenta los espacios, signos de puntuación y tildes.
        /// Ejemplo: Ana lleva al oso la avellana.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N13(string texto)
        {
            Console.WriteLine($"El texto \"{texto}\" {(EsPalindromo(texto) ? "es" : "no es")} palíndromo");
        }

        private static bool EsPalindromo(string texto)
        {
            string textoNormalizado = texto.Trim() // Eliminamos espacios iniciales/finales
                .ToLowerInvariant() // Convertimos todo a minusculas
                .Normalize(NormalizationForm.FormD) // Cescomponemos acentos y caracteres especiales
                .Replace(" ", ""); // Eliminamos espacios en blancos intermedios

            textoNormalizado = Regex.Replace(textoNormalizado, @"\p{P}", ""); // Eliminamos signos de puntuacion con un regex
            textoNormalizado = Regex.Replace(textoNormalizado, @"\p{M}", ""); // Elimina marcas diacríticas (acentos, etc.)

            string textoInvertido = string.Empty;

            for (int i = textoNormalizado.Length - 1; i >= 0; i--)
            {
                textoInvertido += textoNormalizado[i];
            }

            return textoNormalizado == textoInvertido;
        }
        #endregion

        #region Ejercicio 14
        /// <summary>
        /// Escribe una función que calcule y retorne el factorial de un número dado
        /// de forma recursiva.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil
        /// </remarks>
        public static void N14(int num)
        {
            Console.WriteLine($"El factorial de {num} es {CalculaFactorial(num)}");
        }

        private static int CalculaFactorial(int N)
        {
            //Caso base
            if (N == 1)
                return N;
            else
                return N * CalculaFactorial(N - 1);
        }

        #endregion

        #region Ejercicio 15
        /// <summary>
        /// Escribe una función que calcule si un número dado es un número de Armstrong
        /// (o también llamado narcisista).
        /// Si no conoces qué es un número de Armstrong, debes buscar información
        /// al respecto.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil <br/>
        /// <a href="https://es.wikipedia.org/wiki/N%C3%BAmero_narcisista">Explicacion de que es un numero narcisista</a>
        /// </remarks>
        public static void N15(int num)
        {
            Console.WriteLine($"El num \"{num}\" {(EsNarcisista(num) ? "es" : "no es")} un numero de Armstrong (o numero narcisista)");
        }

        //
        private static bool EsNarcisista(int num)
        {
            int numCifras = num.ToString().Length;
            int temp = num;
            double calculo = 0;

            while (temp > 0)
            {
                int cifraActual = temp % 10;
                calculo += Math.Pow(cifraActual, numCifras);
                temp /= 10;
            }

            return Convert.ToInt32(calculo) == num;
        }
        #endregion

        #region Ejercicio 16
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
        public static void N16(string str1, string str2)
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
        #endregion

        #region Ejercicio 17
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
        public static void N17(string str)
        {
            Console.WriteLine($"La frase introducida: \"{str}\"");

            //Usamos un simple Regex para poner a mayuscula la primera letra, incluyendo aquellas palabras que empiezan por signo de puntuacion como "¿hola"
            string output = Regex.Replace(str, @"\b\w", m => m.Value.ToUpper());

            Console.WriteLine($"la misma frase con todas sus palabras en mayuscula inicial: \"{output.Trim()}\"");
        }
        #endregion

        #region Ejercicio 18
        /// <summary>
        /// Crea una función que evalúe si un/a atleta ha superado correctamente una
        /// carrera de obstáculos.
        /// - La función recibirá dos parámetros:
        ///      - Un array que sólo puede contener String con las palabras
        ///        "run" o "jump"
        ///      - Un String que represente la pista y sólo puede contener "_" (suelo)
        ///        o "|" (valla)
        /// - La función imprimirá cómo ha finalizado la carrera:
        ///      - Si el/a atleta hace "run" en "_" (suelo) y "jump" en "|" (valla)
        ///        será correcto y no variará el símbolo de esa parte de la pista.
        ///      - Si hace "jump" en "_" (suelo), se variará la pista por "x".
        ///      - Si hace "run" en "|" (valla), se variará la pista por "/".
        /// - La función retornará un Boolean que indique si ha superado la carrera.
        /// Para ello tiene que realizar la opción correcta en cada tramo de la pista.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N18(string[] acciones, string pista)
        {
            if (!SonAccionesValida(acciones))
            {
                Console.WriteLine("Error: las acciones recibidas contiene más instrucciones aparte de las válidas \"run\" y \"jump\"");
            }
            else if (!EsPistaValida(pista))
            {
                Console.WriteLine($"Error: la pista {pista} no es valida");
            }
            else
            {
                string pistaResultante = string.Empty;
                int maxIndice = Math.Max(acciones.Length, pista.Length); //Obtenemos el indice mas grande de entre el numero de acciones y el numero de obstaculos en la pista

                //Recorremos cada paso en la pista y en las acciones del atleta
                for (int i = 0; i < maxIndice; i++)
                {
                    //Si el indice es mayor o igual al numero de acciones o al numero de obstaculos en la pista
                    //añadimos un '?' a la pista resultante
                    if (i >= acciones.Length || i >= pista.Length)
                    {
                        pistaResultante += '?';
                        continue;
                    }

                    //Si el atleta corre en el suelo y salta la valla, no cambiamos la pista
                    //Si el atleta salta en el suelo, cambiamos la pista por 'x'
                    //Si el atleta corre en la valla, cambiamos la pista por '/'
                    if (acciones[i] == "run")
                    {
                        pistaResultante += pista[i] == '_' ? pista[i] : '/';
                    }
                    else
                    {
                        pistaResultante += pista[i] == '|' ? pista[i] : 'x';
                    }
                }

                Console.WriteLine($"La pista \"{pista}\" ha quedado asi tras el paso del atleta: \"{pistaResultante}\"");
                bool haSuperadoLaCarrera = pista == pistaResultante;
                Console.WriteLine($"El atleta {(haSuperadoLaCarrera ? "SI" : "NO")} ha superado la carrera");
            }
        }

        private static bool SonAccionesValida(string[] acciones)
        {
            return acciones.All(accion => accion == "run" || accion == "jump");
        }

        private static bool EsPistaValida(string pista)
        {
            return Regex.IsMatch(pista, "^[_|]*$");
        }


        #endregion

        #region Ejercicio 19
        /// <summary>
        /// Crea una función que analice una matriz 3x3 compuesta por "X" y "O"
        /// y retorne lo siguiente:
        /// - "X" si han ganado las "X"
        /// - "O" si han ganado los "O"
        /// - "Empate" si ha habido un empate
        /// - "Nulo" si la proporción de "X", de "O", o de la matriz no es correcta.
        ///   O si han ganado los 2.
        /// Nota: La matriz puede no estar totalmente cubierta.
        /// Se podría representar con un vacío "", por ejemplo.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Difícil
        /// </remarks>
        public static void N19(TresEnRayaValor[,] tablero)
        {
            TresEnRayaResultado resultado = tablero.EsTableroNulo() ? TresEnRayaResultado.NULO : tablero.ComprobarVictoriaOEmpate();

            tablero.Imprimir();

            Console.WriteLine($"El resultado de esta partida es {resultado}");
            Console.WriteLine("============================================");
        }

        private static bool EsTableroNulo(this TresEnRayaValor[,] tablero)
        {
            // Si el tablero no tiene 9 (3x3) elementos, es nulo
            if (tablero.Length != 9)
            {
                return true;
            }

            int numX = 0;
            int numO = 0;

            // Contamos cuantas X y O hay en el tablero
            foreach (var pieza in tablero)
            {
                if (pieza == TresEnRayaValor.X)
                {
                    numX++;
                }
                else if (pieza == TresEnRayaValor.O)
                {
                    numO++;
                }
            }

            // Si la diferencia entre el numero de X y O es mayor a 1, el tablero es nulo
            if (Math.Abs(numX - numO) > 1)
            {
                return true;
            }

            return false;
        }

        private static TresEnRayaResultado ComprobarVictoriaOEmpate(this TresEnRayaValor[,] tablero)
        {
            // Definimos las combinaciones ganadoras como una matriz de enteros.
            (int, int)[][] combinacionesGanadoras =
            [
                [(0, 0), (0, 1), (0, 2)],
                [(1, 0), (1, 1), (1, 2)],
                [(2, 0), (2, 1), (2, 2)],
                [(0, 0), (1, 0), (2, 0)],
                [(0, 1), (1, 1), (2, 1)],
                [(0, 2), (1, 2), (2, 2)],
                [(0, 0), (1, 1), (2, 2)],
                [(0, 2), (1, 1), (2, 0)]
            ];

            //Planteamos inicialmente un empate
            TresEnRayaResultado resultado = TresEnRayaResultado.EMPATE;

            //Revisamos cada combinacion ganadora
            foreach (var combinacionGanadora in combinacionesGanadoras)
            {
                // Verificamos si los valores en las posiciones ganadoras son iguales y no vacíos.
                if (tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2] != TresEnRayaValor.VACIO &&
                    tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2] == tablero[combinacionGanadora[1].Item1, combinacionGanadora[1].Item2] &&
                    tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2] == tablero[combinacionGanadora[2].Item1, combinacionGanadora[2].Item2])
                {
                    var ganador = tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2];

                    // Verificamos si ya se ha encontrado un ganador diferente anteriormente.
                    if (resultado != TresEnRayaResultado.EMPATE &&
                        (resultado == TresEnRayaResultado.O ? TresEnRayaValor.O : TresEnRayaValor.X) != ganador)
                    {
                        return TresEnRayaResultado.NULO;
                    }

                    // Asignamos el resultado basado en el ganador de la combinación actual.
                    resultado = ganador == TresEnRayaValor.X ? TresEnRayaResultado.X : TresEnRayaResultado.O;
                }
            }

            return resultado;
        }

        private static void Imprimir(this TresEnRayaValor[,] tablero)
        {
            int filas = tablero.GetLength(0);
            int columnas = tablero.GetLength(1);
            string lineaHorizontal = new string('-', columnas * 4 + 1);

            Console.WriteLine();
            Console.WriteLine("Tablero de Tres en Raya:");
            for (int i = 0; i < filas; i++)
            {
                Console.WriteLine(lineaHorizontal);
                for (int j = 0; j < columnas; j++)
                {
                    // Imprimir el borde izquierdo del recuadro y el valor de la ficha
                    Console.Write($"| {(char)tablero[i, j]} ");
                }
                Console.WriteLine("|"); // Cerrar la línea con un borde derecho
            }
            Console.WriteLine(lineaHorizontal);
        }

        #endregion

        #region Ejercicio 20
        /// <summary>
        /// Crea una función que reciba días, horas, minutos y segundos (como enteros)
        /// y retorne su resultado en milisegundos.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil
        /// </remarks>
        public static void N20(int dias, int horas, int minutos, int segundos)
        {
            var milisegundos = TiempoEnMilisegundos(dias, horas, minutos, segundos);

            Console.WriteLine("{0} dias, {1} horas, {2} minutos y {3} segundos hacen un total de {4} milisegundos",
                dias,
                horas,
                minutos,
                segundos,
                milisegundos
            );
        }

        private static long TiempoEnMilisegundos(int dias, int horas, int minutos, int segundos)
        {
            long segundosEnMillis = segundos * 1000;
            long minutosEnMillis = minutos * 60 * 1000;
            long horasEnMillis = horas * 60 * 60 * 1000;
            long diasEnMillis = dias * 24 * 60 * 60 * 1000;

            return diasEnMillis + horasEnMillis + minutosEnMillis + segundosEnMillis;
        }
        #endregion
    }
}