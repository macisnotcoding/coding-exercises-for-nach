using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
