using RetosMoureDev.Models;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que analice una matriz 3x3 compuesta por "X" y "O"
    /// y retorne lo siguiente:
    /// - "X" si han ganado las "X"
    /// - "O" si han ganado los "O"
    /// - "Empate" si ha habido un empate
    /// - "Nulo" si la proporción de "X", de "O", o de la matriz no es correcta.
    ///   O si han ganado los 2.
    /// Nota: La matriz puede no estar totalmente cubierta.
    /// Se podría representar con un vacío "", por ejemplo.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Difícil
    /// </remarks>
    public static class Ejercicio0019
    {
        public static void Run()
        {
            ExecuteLogic(new TresEnRayaValor[,]
            {
                { TresEnRayaValor.X, TresEnRayaValor.O, TresEnRayaValor.X },
                { TresEnRayaValor.O, TresEnRayaValor.X, TresEnRayaValor.O },
                { TresEnRayaValor.O, TresEnRayaValor.O, TresEnRayaValor.X }
            });
            ExecuteLogic(new TresEnRayaValor[,]
            {
                { TresEnRayaValor.VACIO, TresEnRayaValor.O, TresEnRayaValor.X },
                { TresEnRayaValor.VACIO, TresEnRayaValor.X, TresEnRayaValor.O },
                { TresEnRayaValor.VACIO, TresEnRayaValor.O, TresEnRayaValor.X }
            });
            ExecuteLogic(new TresEnRayaValor[,]
            {
                { TresEnRayaValor.O, TresEnRayaValor.O, TresEnRayaValor.O },
                { TresEnRayaValor.O, TresEnRayaValor.X, TresEnRayaValor.X },
                { TresEnRayaValor.O, TresEnRayaValor.X, TresEnRayaValor.X }
            });
            ExecuteLogic(new TresEnRayaValor[,]
            {
                { TresEnRayaValor.X, TresEnRayaValor.O, TresEnRayaValor.X },
                { TresEnRayaValor.X, TresEnRayaValor.X, TresEnRayaValor.O },
                { TresEnRayaValor.X, TresEnRayaValor.X, TresEnRayaValor.X }
            });
        }

        private static void ExecuteLogic(TresEnRayaValor[,] tablero)
        {
            TresEnRayaResultado resultado = tablero.EsTableroNulo() ? TresEnRayaResultado.NULO : tablero.ComprobarVictoriaOEmpate();

            tablero.Imprimir();

            Console.WriteLine($"El resultado de esta partida es {resultado}");
            Console.WriteLine("============================================");
        }

        private static bool EsTableroNulo(this TresEnRayaValor[,] tablero)
        {
            // Si el tablero no tiene 9 (3x3) elementos, es nulo
            if (tablero.Length != 9)
            {
                return true;
            }

            int numX = 0;
            int numO = 0;

            // Contamos cuantas X y O hay en el tablero
            foreach (var pieza in tablero)
            {
                if (pieza == TresEnRayaValor.X)
                {
                    numX++;
                }
                else if (pieza == TresEnRayaValor.O)
                {
                    numO++;
                }
            }

            // Si la diferencia entre el numero de X y O es mayor a 1, el tablero es nulo
            if (Math.Abs(numX - numO) > 1)
            {
                return true;
            }

            return false;
        }

        private static TresEnRayaResultado ComprobarVictoriaOEmpate(this TresEnRayaValor[,] tablero)
        {
            // Definimos las combinaciones ganadoras como una matriz de enteros.
            (int, int)[][] combinacionesGanadoras =
            [
                [(0, 0), (0, 1), (0, 2)],
                [(1, 0), (1, 1), (1, 2)],
                [(2, 0), (2, 1), (2, 2)],
                [(0, 0), (1, 0), (2, 0)],
                [(0, 1), (1, 1), (2, 1)],
                [(0, 2), (1, 2), (2, 2)],
                [(0, 0), (1, 1), (2, 2)],
                [(0, 2), (1, 1), (2, 0)]
            ];

            //Planteamos inicialmente un empate
            TresEnRayaResultado resultado = TresEnRayaResultado.EMPATE;

            //Revisamos cada combinacion ganadora
            foreach (var combinacionGanadora in combinacionesGanadoras)
            {
                // Verificamos si los valores en las posiciones ganadoras son iguales y no vacíos.
                if (tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2] != TresEnRayaValor.VACIO &&
                    tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2] == tablero[combinacionGanadora[1].Item1, combinacionGanadora[1].Item2] &&
                    tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2] == tablero[combinacionGanadora[2].Item1, combinacionGanadora[2].Item2])
                {
                    var ganador = tablero[combinacionGanadora[0].Item1, combinacionGanadora[0].Item2];

                    // Verificamos si ya se ha encontrado un ganador diferente anteriormente.
                    if (resultado != TresEnRayaResultado.EMPATE &&
                        (resultado == TresEnRayaResultado.O ? TresEnRayaValor.O : TresEnRayaValor.X) != ganador)
                    {
                        return TresEnRayaResultado.NULO;
                    }

                    // Asignamos el resultado basado en el ganador de la combinación actual.
                    resultado = ganador == TresEnRayaValor.X ? TresEnRayaResultado.X : TresEnRayaResultado.O;
                }
            }

            return resultado;
        }

        private static void Imprimir(this TresEnRayaValor[,] tablero)
        {
            int filas = tablero.GetLength(0);
            int columnas = tablero.GetLength(1);
            string lineaHorizontal = new string('-', columnas * 4 + 1);

            Console.WriteLine();
            Console.WriteLine("Tablero de Tres en Raya:");
            for (int i = 0; i < filas; i++)
            {
                Console.WriteLine(lineaHorizontal);
                for (int j = 0; j < columnas; j++)
                {
                    // Imprimir el borde izquierdo del recuadro y el valor de la ficha
                    Console.Write($"| {(char)tablero[i, j]} ");
                }
                Console.WriteLine("|"); // Cerrar la línea con un borde derecho
            }
            Console.WriteLine(lineaHorizontal);
        }
    }
}