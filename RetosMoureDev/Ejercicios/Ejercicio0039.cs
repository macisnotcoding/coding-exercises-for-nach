using System.Numerics;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que se encargue de transformar un número binario
    /// a decimal sin utilizar funciones propias del lenguaje que
    /// lo hagan directamente.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0039
    {
        public static void Run()
        {
            ExecuteLogic("00110");
            ExecuteLogic("01100");
            ExecuteLogic("000000000");
            ExecuteLogic("00210");
            ExecuteLogic("001101001110");
            ExecuteLogic("00b10");
            ExecuteLogic("");
            ExecuteLogic("-00110");
            ExecuteLogic(" ");
            ExecuteLogic(" 10011");
            ExecuteLogic("1O1OO11");
            //EXTRA
            //convertir 1011001 en base 37 a decimal
            ExecuteLogic("1011001", 37);
        }

        private static void ExecuteLogic(string numero, int? @base = null)
        {
            string binarioNormalizado = numero.Trim().Replace(" ", "");

            if (@base is null)
            {
                if (!binarioNormalizado.EsBinario())
                {
                    Console.WriteLine($"Error: {numero} no es un binario válido");
                    return;
                }

                var resultado = binarioNormalizado.ConvertirADecimal();
                Console.WriteLine($"{binarioNormalizado} en binario es {resultado} en decimal");
            }
            else
            {
                var resultado = numero.ConvertirADecimal(@base.Value);
                Console.WriteLine($"{binarioNormalizado} en base {@base.Value} es {resultado} en decimal");
            }
        }

        private static bool EsBinario(this string binario)
        {
            if(string.IsNullOrWhiteSpace(binario))
            {
                return false;
            }

            foreach(char caracter in binario)
            { 
                if(caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Usamos la <a href="https://www.wikihow.com/Convert-from-Binary-to-Decimal">Positional Notation</a>
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static double ConvertirADecimal(this string binario)
        {
            double resultado = 0;
            int maxPotencia = binario.Length - 1;

            for(int i = 0; i < binario.Length; i++)
            {
                int num = binario[i] - '0'; // Convertir de char a int correctamente
                resultado += Math.Pow(2, maxPotencia - i) * num;
            }

            return resultado;
        }
        /// <summary>
        /// Usamos el <a href="https://www.wikihow.com/Convert-from-Binary-to-Decimal">desplazamiento de bit (doubling)</a>, util para convertir desde cualquier base, no solo binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static BigInteger ConvertirADecimal(this string numero, int @base)
        {
            //APUNTE: esta aproximacion SOLO funciona cuando no se poseen caracteres especiales para numeros mas allá del 9 (A,B,C,D,etc.)
            //Si quisieramos una implementacion correcta, habría que amplicar la conversion del char para considerar dichas letras/caracteres especiales en caso de bases > 36
            //#outofscope
            BigInteger resultado = 0;
            foreach (char c in numero)
            {
                resultado = resultado * @base + (c - '0');
            }
            return resultado;
        }
    }
}