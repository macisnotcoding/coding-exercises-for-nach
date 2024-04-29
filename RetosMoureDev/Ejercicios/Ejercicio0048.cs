using System.Text;
using System.Text.RegularExpressions;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que reciba un texto y retorne la vocal que
    /// más veces se repita.
    /// - Ten cuidado con algunos casos especiales.
    /// - Si no hay vocales podrá devolver vacío.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0048
    {
        public static void Run()
        {
            ExecuteLogic("aaaaaeeeeiiioou");
            ExecuteLogic("AáaaaEeeeIiiOoU");
            ExecuteLogic("eeeeiiioouaaaaa");
            ExecuteLogic(".-Aá?aaaBbEeeweIiiOoU:");
            ExecuteLogic(".-Aá?aaa BbEeew eIiiOoU:");
            ExecuteLogic(".-Aá?aaa BbEeew eEIiiOoU:");
            ExecuteLogic(".-Aá?aaa BbEeew eEIiiOoUuuuuu:");
            ExecuteLogic("aeiou");
            ExecuteLogic("brp qyz");
        }

        private static void ExecuteLogic(string texto)
        {
            var vocalMasRepetida = ObtenerVocalMasRepetida(texto);
            if (vocalMasRepetida is not null)
            {
                Console.WriteLine($"La vocal que más veces se repite en \"{texto}\" es {string.Join(", ", vocalMasRepetida)}");
            }
            else
            {
                Console.WriteLine($"No hay ninguna vocal más repetida en \"{texto}\"");
            }
        }

        private static char? ObtenerVocalMasRepetida(string texto)
        {
            Dictionary<char, int> letrasProcesadas = [];

            //Copiado del ejercicio 13
            string textoNormalizado = texto.Trim() // Eliminamos espacios iniciales/finales
                .ToLowerInvariant() // Convertimos todo a minusculas
                .Normalize(NormalizationForm.FormD) // Cescomponemos acentos y caracteres especiales
                .Replace(" ", ""); // Eliminamos espacios en blancos intermedios

            textoNormalizado = Regex.Replace(textoNormalizado, @"\p{P}", ""); // Eliminamos signos de puntuacion con un regex
            textoNormalizado = Regex.Replace(textoNormalizado, @"\p{M}", ""); // Elimina marcas diacríticas (acentos, etc.)
            //

            foreach (var letra in textoNormalizado.Where(letra => letra.EsVocal()))
            {
                if (letrasProcesadas.TryGetValue(letra, out int value))
                {
                    letrasProcesadas[letra] = ++value;
                }
                else
                {
                    letrasProcesadas[letra] = 1;
                }
            }

            List<char> vocalesMasRepetidas = letrasProcesadas
                .Where(x => x.Value == letrasProcesadas.Values.Max())
                .Select(x => x.Key)
                .ToList();

            return vocalesMasRepetidas.Count == 1 ? vocalesMasRepetidas.FirstOrDefault() : null;
        }

        private static bool EsVocal(this char letra)
        {
            return "aeiouAEIOU".Contains(letra);
        }
    }
}