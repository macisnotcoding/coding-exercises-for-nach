using RetosMoureDev.Models;
using System.Numerics;
using System.Text;

namespace RetosMoureDev.Ejercicios
{
    public static class Ejercicios21a40
    {
        #region Ejercicio 21 - Parando el tiempo
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

        #region Ejercicio 22 - Calculadora .txt
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

        #region Ejercicio 23 - Conjuntos
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

        #region Ejercicio 24 - Maximo Comun Divisor y Minimo Comun Multiplo
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

        #region Ejercicio 25 - Iteration master
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

        #region Ejercicio 26 - Piedra, Papel, Tijera
        /// <summary>
        /// Crea un programa que calcule quién gana más partidas al piedra,
        /// papel, tijera.
        /// - El resultado puede ser: "Player 1", "Player 2", "Tie" (empate)
        /// - La función recibe un listado que contiene pares, representando cada jugada.
        /// - El par puede contener combinaciones de "R" (piedra), "P" (papel)
        ///   o "S" (tijera).
        /// - Ejemplo. Entrada: [("R","S"), ("S","R"), ("P","S")]. Resultado: "Player 2".
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N26(List<(PiedraPapelTijeras, PiedraPapelTijeras)> jugadas)
        {
            int victoriasJugador1 = 0;
            int victoriasJugador2 = 0;

            foreach(var jugada in jugadas)
            {
                PiedraPapelTijerasResultado resultado = jugada.CalcularGanador();

                switch (resultado)
                {
                    case PiedraPapelTijerasResultado.PLAYER_1:
                        victoriasJugador1++;
                        break;
                    case PiedraPapelTijerasResultado.PLAYER_2:
                        victoriasJugador2++;
                        break;
                    default:
                        break;
                }
            }

            jugadas.ImprimirJuego();

            Console.WriteLine($"La partida se ha saldado con una puntuacion de {victoriasJugador1} a {victoriasJugador2}");
            if(victoriasJugador1 == victoriasJugador2)
            {
                Console.WriteLine("La partida ha quedado en empate");
            }
            else
            {
                Console.WriteLine($"¡Gana el jugador {(victoriasJugador1 > victoriasJugador2 ? "1" : "2")}!");
            }
        }

        private static PiedraPapelTijerasResultado CalcularGanador(this (PiedraPapelTijeras, PiedraPapelTijeras) jugada)
        {
            if(jugada.Item1 == jugada.Item2)
            {
                return PiedraPapelTijerasResultado.TIE;
            }
            
            if((jugada.Item1 == PiedraPapelTijeras.PIEDRA && jugada.Item2 == PiedraPapelTijeras.TIJERAS)
                || (jugada.Item1 == PiedraPapelTijeras.PAPEL && jugada.Item2 == PiedraPapelTijeras.PIEDRA)
                || (jugada.Item1 == PiedraPapelTijeras.TIJERAS && jugada.Item2 == PiedraPapelTijeras.PAPEL))
            {
                return PiedraPapelTijerasResultado.PLAYER_1;
            }

            return PiedraPapelTijerasResultado.PLAYER_2;
        }

        public static void ImprimirJuego(this List<(PiedraPapelTijeras, PiedraPapelTijeras)> jugadas)
        {
            StringBuilder resultado = new StringBuilder();
            int juego = 1;

            resultado.AppendLine("Resultados del Juego de Piedra, Papel o Tijeras:");
            foreach (var (jugador1, jugador2) in jugadas)
            {
                resultado.AppendLine($"Juego {juego++}: {ConvertirASimbolo(jugador1)} vs {ConvertirASimbolo(jugador2)}");
            }

            Console.WriteLine(resultado.ToString());
        }

        private static string ConvertirASimbolo(PiedraPapelTijeras jugada)
        {
            switch (jugada)
            {
                case PiedraPapelTijeras.PIEDRA:
                    return "(O)";
                case PiedraPapelTijeras.PAPEL:
                    return "[_]";
                case PiedraPapelTijeras.TIJERAS:
                    return "8<";
                default:
                    return "";
            }
        }
        #endregion

        #region Ejercicio 27 - Dibujando poligonos
        /// <summary>
        /// Crea un programa que dibuje un cuadrado o un triángulo con asteriscos "*".
        /// - Indicaremos el tamaño del lado y si la figura a dibujar es una u otra.
        /// - EXTRA: ¿Eres capaz de dibujar más figuras?
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil
        /// </remarks>
        public static void N27(int size, TipoFigura tipoFigura)
        {
            switch(tipoFigura)
            {
                case TipoFigura.CUADRADO:
                    DibujarCuadrado(size);
                    break;
                case TipoFigura.TRIANGULO:
                    DibujarTriangulo(size);
                    break;
                case TipoFigura.CIRCULO:
                    DibujarCirculo(size);
                    break;
                default:
                    Console.WriteLine("Figura desconocida");
                    break;
            }
        }

        private static void DibujarCuadrado(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(new string('*', size));
            }
        }

        private static void DibujarTriangulo(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }

        private static void DibujarCirculo(int radio) // EXTRA
        {
            double r_in = radio - 0.4;
            double r_out = radio + 0.4;
            for (int y = radio; y >= -radio; --y)
            {
                for (int x = -radio; x < r_out; x++)
                {
                    double value = x * x + y * y;
                    if (value >= r_in * r_in && value <= r_out * r_out)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Ejercicio 28 - Vectores ortogonales
        /// <summary>
        /// Crea un programa que determine si dos vectores son ortogonales.
        /// - Los dos array deben tener la misma longitud.
        /// - Cada vector se podría representar como un array. Ejemplo: [1, -2]
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Fácil <br/>
        /// <a href="https://es.wikipedia.org/wiki/Ortogonalidad_(matem%C3%A1tica)#:~:text=Ortogonalidad%20y%20perpendicularidad%5B,partir%20del%20producto%20interior.">Que es y como se averigua la ortogonalidad</a>
        /// </remarks>
        public static void N28(List<int> vector1, List<int> vector2)
        {
            if(vector1.Count != vector2.Count)
            {
                Console.WriteLine($"Los vectores ({string.Join(", ", vector1)}) y ({string.Join(", ", vector2)}) NO son ortogonales porque tienen dimensiones distintas");
            }
            else
            {
                //Version iterativa
                //int productoEscalar = 0;
                //for(int i = 0; i < vector1.Count; i++)
                //{
                //    productoEscalar += vector1[i] * vector2[i];
                //}

                //Version con LINQ
                int productoEscalar = vector1.Zip(vector2, (v1, v2) => v1 * v2).Sum();

                Console.WriteLine($"Los vectores ({string.Join(", ", vector1)}) y ({string.Join(", ", vector2)}) {(productoEscalar == 0 ? "SI" : "NO")} son ortogonales");
            }
        }
        #endregion

        #region Ejercicio 29 - Maquina expendedora
        /// <summary>
        /// Simula el funcionamiento de una máquina expendedora creando una operación
        /// que reciba dinero (array de monedas) y un número que indique la selección
        /// del producto.
        /// - El programa retornará el nombre del producto y un array con el dinero
        ///   de vuelta (con el menor número de monedas).
        /// - Si el dinero es insuficiente o el número de producto no existe,
        ///   deberá indicarse con un mensaje y retornar todas las monedas.
        /// - Si no hay dinero de vuelta, el array se retornará vacío.
        /// - Para que resulte más simple, trabajaremos en céntimos con monedas
        ///   de 5, 10, 50, 100 y 200.
        /// - Debemos controlar que las monedas enviadas estén dentro de las soportadas.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Medio
        /// </remarks>
        public static void N29(List<Monedas> monedas, int codigo)
        {
            Dictionary<int, Tuple<string, int>> productos = new()
            {
                {1, Tuple.Create("Agua", 50)},
                {2, Tuple.Create("Coca-Cola", 100)},
                {4, Tuple.Create("Cerveza", 155)},
                {5, Tuple.Create("Pizza", 200)},
                {10, Tuple.Create("Donut", 75)}
            };

            //Comprobamos si el producto existe
            if(!productos.TryGetValue(codigo, out var producto))
            {
                Console.WriteLine($"Error: Has introducido un codigo de producto ({codigo}) que no existe");
                return;
            }
            
            int dineroTotalIntroducido = monedas.Sum(x => (int)x);

            //Comprobamos si el dinero introducido es suficiente
            if(dineroTotalIntroducido < producto.Item2)
            {
                Console.WriteLine($"Error: Has introducido {dineroTotalIntroducido} centimos y el producto {producto.Item1} vale {producto.Item2}. Te falta dinero");
                return;
            }

            int dineroPendiente = dineroTotalIntroducido - producto.Item2;
            List<Monedas> monedasADevolver = CalcularMonedasADevolver(dineroPendiente)
                .OrderBy(x => (int)x)
                .ToList();

            Console.WriteLine($"¡Aquí tienes tu {producto.Item1}!");
            if(dineroPendiente != 0)
            {
                Console.WriteLine($"Te devuelvo {dineroPendiente} en monedas de {string.Join(", ", monedasADevolver.Select(x => (int)x).ToList())} centimos");
            }
        }

        private static List<Monedas> CalcularMonedasADevolver(int dineroPendiente, List<Monedas>? monedas = null)
        {
            //Si no se ha pasado la lista de monedas, la inicializamos
            monedas ??= new List<Monedas>();
            //Creamos una variable auxiliar para no modificar el dinero pendiente original
            int dineroPendienteActualizado = dineroPendiente;

            //Caso base
            //Si el dinero pendiente es 0, devolvemos la lista de monedas
            if(dineroPendiente == 0)
            {
                return monedas.ToList();
            }

            //Caso recursivo
            //Vamos a buscar la moneda mas grande que sea menor o igual al dinero pendiente
            foreach (Monedas moneda in Enum.GetValues(typeof(Monedas)).Cast<Monedas>().OrderByDescending(x => x))
            {
                //Si la moneda es menor o igual al dinero pendiente, la añadimos a la lista de monedas y actualizamos el dinero pendiente
                if((int)moneda <= dineroPendiente)
                {
                    dineroPendienteActualizado -= (int)moneda;
                    monedas.Add(moneda);
                    break;
                }
            }

            //Llamada recursiva
            return CalcularMonedasADevolver(dineroPendienteActualizado, monedas);
        }
        #endregion

        #region Ejercicio 30 - Ordena la lista
        /// <summary>
        /// Crea una función que ordene y retorne una matriz de números.
        /// - La función recibirá un listado (por ejemplo [2, 4, 6, 8, 9]) y un parámetro
        ///   adicional "Asc" o "Desc" para indicar si debe ordenarse de menor a mayor
        ///   o de mayor a menor.
        /// - No se pueden utilizar funciones propias del lenguaje que lo resuelvan
        ///   automáticamente.
        /// </summary>
        /// 
        /// <remarks>
        /// Dificultad: Facil
        /// </remarks>
        public static void N30(int[] listado, bool ordenarAsc)
        {
            Console.WriteLine($"Listado original {{{string.Join(", ", listado)}}}");
            listado.Ordenar(ordenarAsc);
            Console.WriteLine($"Listado ordenado {(ordenarAsc ? "ascendentemente" : "descendentemente")} {{{string.Join(", ", listado)}}}");
            
        }

        /// <summary>
        /// Ordena una lista siguiendo el algoritmo Bubble sort.
        /// </summary>
        /// 
        /// <remarks>
        /// Hay muchas formas y colores de ordenar una lista. Muchos muchos algoritmos, todos mas o menos eficientes.
        /// Yo he utilizado el mas sencillo de todos, "Bubble sort". Puedes echar un ojo <a href="https://www.geeksforgeeks.org/bubble-sort/">en esta web para entender como funciona</a>  
        /// </remarks>
        /// <param name="listado">Lista de enteros a ordenar</param>
        /// <param name="ordenarAsc">Indica si se debe ordenar de menor a mayor (true) o de mayor a menor (false)</param>
        private static void Ordenar(this int[] listado, bool ordenarAsc)
        {
            for (int i = 0; i < listado.Length; i++)
            {
                for (int j = 0; j < listado.Length - 1; j++)
                {
                    //variamos la condicion del if en funcion de si es Asc o Desc para no escribir dos veces la misma logica
                    if (ordenarAsc ? listado[j] > listado[j + 1] : listado[j] < listado[j + 1])
                    {
                        //Si se cumple la condicion, los intercambiamos de posicion
                        int temp = listado[j];
                        listado[j] = listado[j + 1];
                        listado[j + 1] = temp;
                    }
                }
            }
        }
        #endregion
    }
}