namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que transforme grados Celsius en Fahrenheit
    /// y viceversa.
    /// - Para que un dato de entrada sea correcto debe poseer un símbolo "°"
    ///   y su unidad ("C" o "F").
    /// - En caso contrario, retornará un error.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0043
    {
        private class ConversorTemperaturaException(string message) : Exception(message)
        {
        }

        public static void Run()
        {
            ExecuteLogic("100°C");
            ExecuteLogic("100°F");
            ExecuteLogic("100C");
            ExecuteLogic("100F");
            ExecuteLogic("100");
            ExecuteLogic("100");
            ExecuteLogic("- 100 °C ");
            ExecuteLogic("- 100 °F ");
            ExecuteLogic("100A°C");
            ExecuteLogic("100A°F");
            ExecuteLogic("°C");
            ExecuteLogic("°F");
        }

        private static void ExecuteLogic(string input)
        {
            try
            {
                string resultado = input.ConvertirTemperatura();

                Console.WriteLine($"{input} son {resultado}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: No se puede hacer la conversion: {ex.Message}");
            }
        }

        private static string ConvertirTemperatura(this string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                throw new ConversorTemperaturaException($"El input \"{input}\" esta vacio");
            }

            var inputNormalizado = input.Trim().Replace(" ", "");

            if (inputNormalizado.Contains("°C"))
            {
                double gradosCelsius = double.Parse(inputNormalizado.Replace("°C", ""));
                double resultado = Math.Round((gradosCelsius * 9 / 5) + 32, 2);

                return $"{resultado}°F";
            }
            else if (inputNormalizado.Contains("°F"))
            {
                double gradosFahrenheit = double.Parse(inputNormalizado.Replace("°F", ""));
                double resultado = Math.Round((gradosFahrenheit - 32) * 5 / 9, 2);

                return $"{resultado}°C";
            }
            else
            {
                throw new ConversorTemperaturaException($"El input \"{input}\" no especifica ni grados Celsius ni Fahrenheit");
            }
        }
    }
}