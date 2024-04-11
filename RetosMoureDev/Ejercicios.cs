using RetosMoureDev.Models.Poligonos;

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
        /// 
        /// <remarks>
        /// Dificultad: Facil
        /// </remarks>
        /// </summary>
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
        ///         
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        /// </summary>
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
        ///   
        /// <remarks>
        /// Dificultad: Dificil
        /// </remarks>
        /// </summary>
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
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        /// </summary>
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
        /// 
        /// <remarks>
        /// Dificultad: Facil
        /// </remarks>
        /// </summary>
        public static void N5(Poligono poligono)
        {
            Console.WriteLine("El área del poligono es {0}", poligono.CalcularArea());
        }

        #endregion
    }
}