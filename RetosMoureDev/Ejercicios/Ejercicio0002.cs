namespace RetosMoureDev.Ejercicios
{
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
    public class Ejercicio0002
    {
        public static void Run()
        {
            ExecuteLogic("aba", "aab");
        }

        private static void ExecuteLogic(string word1, string word2)
        {
            bool result = EsAnagrama(word1, word2);

            Console.WriteLine("¿Es {0} un anagrama de {1}?: {2}", word1, word2, result ? "Si" : "No");
        }

        private static bool EsAnagrama(string word1, string word2)
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
    }
}