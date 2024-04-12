using RetosMoureDev.Models.Poligonos;
using System.Drawing;
using System.Text;

namespace RetosMoureDev
{
    public static class Ejercicios
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

                if(i % 3 == 0)
                {
                    output += "fizz";
                }
                
                if(i % 5 == 0)
                {
                    output += "buzz";
                }

                if(string.IsNullOrWhiteSpace(output)) 
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

            for(int i = 1; i <= 100; i++)
            {
                if(EsPrimo(i))
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
                using(var stream = await response.Content.ReadAsStreamAsync())
                {
                    #region Windows only
                    var imagen = Image.FromStream(stream);
                    int ancho = imagen.Width;
                    int alto = imagen.Height;

                    //Ahora que tenemos el ancho y alto de la imagen (1920x1080px por ejemplo) calculamos el maximo comun divisor (MCD) de ambos
                    //y dividimos cada proporcion por este para sacar el ratio
                    //Por ejemplo, si el MCD de 1920 y 1080 es 120, el aspect ratio de la imagen es 16:9
                    int mcd = MCD(ancho, alto);

                    return $"{ancho/mcd}:{alto/mcd}";
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

        //Calcula el maximo comun divisor de dos numeros
        private static int MCD(int a, int b)
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
            for(int i = 0;  i < palabraInvertida.Length; i++)
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
            foreach(var palabraConOcurrencia in ObtenerPalabrasConOcurrencias(oracionNormalizada))
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
                if(char.IsLetterOrDigit(caracter) || char.IsWhiteSpace(caracter))
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
            foreach(string palabra in palabasDeOracion)
            {
                if(palabrasConOcurrencias.ContainsKey(palabra))
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
            while(numero > 0)
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
            if(EsMorse(mensaje))
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
            foreach(char letra in mensaje)
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
                if(diccionarioNaturalMorse.ContainsKey(letra))
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
            foreach(string palabra in mensaje.ToUpper().Split("  "))
            {
                foreach(string simbolos in palabra.Split(" "))
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
    }
}