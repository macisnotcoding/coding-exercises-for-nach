namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Lee el fichero "Ejercicio22.txt" incluido en el proyecto, calcula su
    /// resultado e imprímelo.
    /// - El .txt se corresponde con las entradas de una calculadora.
    /// - Cada línea tendrá un número o una operación representada por un
    ///   símbolo (alternando ambos).
    /// - Soporta números enteros y decimales.
    /// - Soporta las operaciones suma "+", resta "-", multiplicación "*"
    ///   y división "/".
    /// - El resultado se muestra al finalizar la lectura de la última
    ///   línea (si el .txt es correcto).
    /// - Si el formato del .txt no es correcto, se indicará que no se han
    ///   podido resolver las operaciones.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0022
    {
        public static void Run()
        {
            ExecuteLogic();
        }

        private static void ExecuteLogic()
        {
            string ruta = "./Resources/Ejercicio22.txt";
            string[] lineas = File.ReadAllLines(ruta);

            try
            {
                double? resultado = ProcesarCalculoTxt(lineas);

                if (resultado.HasValue)
                {
                    Console.WriteLine($"El resultado del calculo detallado en \"Ejercicio22.txt\" es {resultado}");
                }
                else
                {
                    throw new InvalidOperationException("El formato del .txt no es correcto");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.Error.WriteLine($"El programa no se puede ejecutar. {ex.Message}");
            }
        }

        public static double? ProcesarCalculoTxt(string[] lineas)
        {
            string ultimoOperador = string.Empty;
            double? resultado = null;

            // Procesar cada línea del .txt
            foreach (string line in lineas)
            {
                // Si es un número, se realiza la operación correspondiente
                if (double.TryParse(line, out double numero))
                {
                    if (resultado == null) // Si es el primer número, se guarda en lugar de hacer calculos
                    {
                        resultado = numero;
                    }
                    else
                    {
                        switch (ultimoOperador)
                        {
                            case "+":
                                resultado += numero;
                                break;
                            case "-":
                                resultado -= numero;
                                break;
                            case "*":
                                resultado *= numero;
                                break;
                            case "/":
                                resultado /= numero;
                                break;
                            default:
                                throw new InvalidOperationException("El formato del .txt no es correcto");
                        }
                        ultimoOperador = string.Empty;
                    }
                }
                else // Si es un operador, se guarda para la siguiente operación
                {
                    if (ultimoOperador == string.Empty) // Si no hay operador, se guarda
                    {
                        ultimoOperador = line;
                    }
                    else // Si ya hay un operador, se lanza una excepción
                    {
                        throw new InvalidOperationException("El formato del .txt no es correcto");
                    }
                }
            }

            return resultado;
        }
    }
}