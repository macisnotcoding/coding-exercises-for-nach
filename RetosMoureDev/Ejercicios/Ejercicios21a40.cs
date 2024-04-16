namespace RetosMoureDev.Ejercicios
{
    public static class Ejercicios21a40
    {
        #region Ejercicio 21
        /// <summary>
        /// Crea una función que sume 2 números y retorne su resultado pasados
        /// unos segundos.
        /// - Recibirá por parámetros los 2 números a sumar y los segundos que
        ///   debe tardar en finalizar su ejecución.
        /// - Si el lenguaje lo soporta, deberá retornar el resultado de forma
        ///   asíncrona, es decir, sin detener la ejecución del programa principal.
        ///   Se podría ejecutar varias veces al mismo tiempo.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static async Task N21(int num1, int num2, int secsAEsperar)
        {
            Console.WriteLine($"La suma de {num1} y {num2} se va a realizar dentro de {secsAEsperar} segundos");
            int suma = await SumarConEspera(num1, num2, secsAEsperar);
            Console.WriteLine($"El resultado es {suma}");
        }

        public static async Task<int> SumarConEspera(int num1, int num2, int secsAEsperar)
        {
            await Task.Delay(secsAEsperar * 1000);
            return num1 + num2;
        }
        #endregion

        #region Ejercicio 22
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
        public static void N22()
        {
            string ruta = "./Resources/Ejercicio22.txt";
            string[] lineas = File.ReadAllLines(ruta);

            try
            {
                double? resultado = ProcesarCalculoTxt(lineas);

                if (resultado.HasValue )
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
                if(double.TryParse(line, out double numero))
                {
                    if(resultado == null) // Si es el primer número, se guarda en lugar de hacer calculos
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
                    if(ultimoOperador == string.Empty) // Si no hay operador, se guarda
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
        #endregion

        #region Ejercicio 23
        /// <summary>
        /// Crea una función que reciba dos array de int, un booleano y retorne un array.
        /// - Si el booleano es verdadero buscará y retornará los elementos comunes
        ///   de los dos array.
        /// - Si el booleano es falso buscará y retornará los elementos no comunes
        ///   de los dos array.
        /// - No se pueden utilizar operaciones del lenguaje que
        ///   lo resuelvan directamente.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil
        /// </remarks>
        public static void N23(int[] array1, int[] array2, bool comunes)
        {
            Console.WriteLine($"Conjunto de numeros 1: {string.Join(", ", array1)}");
            Console.WriteLine($"Conjunto de numeros 2: {string.Join(", ", array2)}");

            if (comunes)
            {
                Console.WriteLine($"Los elementos comunes entre ambos son: {string.Join(", ", BuscarElementosComunes(array1, array2))}");
            }
            else
            {
                Console.WriteLine($"Los elementos no comunes entre ambos son: {string.Join(", ", BuscarElementosNoComunes(array1, array2))}");
            }
        }

        private static int[] BuscarElementosComunes(int[] array1, int[] array2)
        {
            var resultado = new HashSet<int>();

            foreach (int i in array1) 
            {
                foreach (int j in array2)
                {
                    if (i == j)
                    {
                        resultado.Add(i);
                        break;
                    }
                }
            }

            return resultado.ToArray();
        }

        private static int[] BuscarElementosNoComunes(int[] array1, int[] array2)
        {
            var resultado = new HashSet<int>();

            // Verificar elementos de array1 que no están en array2
            foreach (int i in array1)
            {
                bool encontrado = false;
                foreach (int j in array2)
                {
                    if (j == i)
                    {
                        encontrado = true;
                        break;
                    }
                }
                
                if(!encontrado)
                {
                    resultado.Add(i);
                }
            }

            // Verificar elementos de array2 que no están en array1
            foreach (int i in array2)
            {
                bool encontrado = false;
                foreach (int j in array1)
                {
                    if (j == i)
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    resultado.Add(i);
                }
            }

            return resultado.ToArray();
        }
        #endregion

        #region Ejercicio 24
        /// <summary>
        /// Crea dos funciones, una que calcule el máximo común divisor (MCD) y otra
        /// que calcule el mínimo común múltiplo (mcm) de dos números enteros.
        /// - No se pueden utilizar operaciones del lenguaje que
        ///   lo resuelvan directamente.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N24(int num1, int num2)
        {
            Console.WriteLine($"El MCD de {num1} y {num2} es {Ejercicios1a20.MCD(num1, num2)}");
            Console.WriteLine($"El mcm de {num1} y {num2} es {mcm(num1, num2)}");
        }

        // Función para calcular el mínimo común múltiplo
        // Se utiliza la fórmula mcm(a, b) = |a * b| / MCD(a, b)
        private static int mcm(int num1, int num2)
        {
            int MCD = Ejercicios1a20.MCD(num1, num2);
            return Math.Abs(num1 * num2) / MCD;
        }
        #endregion

        #region Ejercicio 25
        /// <summary>
        /// Quiero contar del 1 al 100 de uno en uno (imprimiendo cada uno).
        /// ¿De cuántas maneras eres capaz de hacerlo?
        /// Crea el código para cada una de ellas.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil
        /// </remarks>
        public static void N25()
        {
            // 1 Uso de un bucle for clasico:
            Console.WriteLine("**** 1 ****");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }
            // 2 Uso de un bucle while:
            Console.WriteLine("**** 2 ****");
            int j = 1;
            while (j <= 100)
            {
                Console.WriteLine(j);
                j++;
            }

            // 3 Uso de un bucle do-while:
            Console.WriteLine("**** 3 ****");
            int k = 1;
            do
            {
                Console.WriteLine(k);
                k++;
            } while (k <= 100);

            // 4 Uso de foreach con Enumerable.Range:
            Console.WriteLine("**** 4 ****");
            foreach (int num in Enumerable.Range(1, 100))
            {
                Console.WriteLine(num);
            }

            // 5 Uso de for con un paso personalizado:
            Console.WriteLine("**** 5 ****");
            for (int l = 1; l <= 100; l += 1) // Aquí el paso es 1, pero puedes modificarlo.
            {
                Console.WriteLine(l);
            }

            // 6 Uso de Parallel.For para una iteración paralela (útil para tareas que se pueden paralelizar):
            Console.WriteLine("**** 6 ****");
            Parallel.For(1, 101, m =>
            {
                Console.WriteLine(m);
            });

            // 7 Uso de recursión (no recomendado para este rango grande debido al riesgo de desbordamiento de pila):
            Console.WriteLine("**** 7 ****");
            PrintRecursively(1);

            // 8 Uso de LINQ:
            Console.WriteLine("**** 8 ****");
            Enumerable.Range(1, 100).ToList().ForEach(num => Console.WriteLine(num));

        }

        private static void PrintRecursively(int index)
        {
            if (index <= 100)
            {
                Console.WriteLine(index);
                PrintRecursively(index + 1);
            }
        }
        #endregion
    }
}