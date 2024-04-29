using RetosMoureDev.Models.Robots;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Calcula dónde estará un robot (sus coordenadas finales) que se
    /// encuentra en una cuadrícula representada por los ejes "x" e "y".
    /// - El robot comienza en la coordenada (0, 0).
    /// - Para indicarle que se mueva, le enviamos un array formado por enteros
    ///   (positivos o negativos) que indican la secuencia de pasos a dar.
    /// - Por ejemplo: [10, 5, -2] indica que primero se mueve 10 pasos, se detiene,
    ///   luego 5, se detiene, y finalmente 2.
    ///   El resultado en este caso sería (x: -5, y: 12)
    /// - Si el número de pasos es negativo, se desplazaría en sentido contrario al
    ///   que está mirando.
    /// - Los primeros pasos los hace en el eje "y". Interpretamos que está mirando
    ///   hacia la parte positiva del eje "y".
    /// - El robot tiene un fallo en su programación: cada vez que finaliza una
    ///   secuencia de pasos, gira 90 grados en el sentido contrario a las agujas
    ///   del reloj.
    /// </summary>
    /// 
    /// Aclaracion: 
    /// Después del primer paso, el robot está en (0, 10).
    /// Después del segundo paso, el robot está en(-5, 10).
    /// Después del tercer paso, el robot está en(-5, 12).
    /// Despues de cada paso, el robot gira 90 grados. Ni pues de cada conjunto de pasos como 
    /// da a entender erroneamente el enunciado.
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0047
    {   
        public static void Run()
        {
            ExecuteLogic([10, 5, -2]);
            ExecuteLogic([0, 0, 0]);
            ExecuteLogic([]);
            ExecuteLogic([-10, -5, 2]);
            ExecuteLogic([-10, -5, 2, 4, -8]);
        }

        private static void ExecuteLogic(int[] conjuntoPasos)
        {
            Console.WriteLine($"Comenzamos la ejecucion del programa con los pasos [{string.Join(", ", conjuntoPasos)}]");
            Robot robot = new();

            if (conjuntoPasos.Length > 0)
            {
                Console.WriteLine($"El robot comenzó en las coordenadas {robot.Coordenadas} mirando hacia {robot.DireccionActual}");
                foreach (int pasos in conjuntoPasos)
                {
                    Console.WriteLine($"El robot recibió la orden de moverse {pasos} pasos hacia {robot.DireccionActual}");
                    robot.Mover(pasos);
                    Console.WriteLine($"El robot terminó la orden en las coordenadas {robot.Coordenadas}, pero ahora mira hacia {robot.DireccionActual}");
                }
            }
            else
            {
                Console.WriteLine($"Como el set de instrucciones esta vacio el robot no se mueve");
            }
            Console.WriteLine($"El robot terminó el programa en las coordenadas {robot.Coordenadas} mirando hacia {robot.DireccionActual}");
        }
    }
}