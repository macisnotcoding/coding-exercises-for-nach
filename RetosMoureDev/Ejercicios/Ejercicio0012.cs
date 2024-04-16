namespace RetosMoureDev.Ejercicios
{
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
    public static class Ejercicio0012
    {
        public static void Run()
        {
            ExecuteLogic("pepe", "palotes");
        }

        private static void ExecuteLogic(string str1, string str2)
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
    }
}