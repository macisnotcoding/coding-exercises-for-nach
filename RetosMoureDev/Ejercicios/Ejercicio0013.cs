using System.Text.RegularExpressions;
using System.Text;

namespace RetosMoureDev.Ejercicios
{
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
    public static class Ejercicio0013
    {
        public static void Run()
        {
            ExecuteLogic("baoáb !!@ - ");
        }

        private static void ExecuteLogic(string texto)
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
    }
}