using RetosMoureDev.Models;
using System.Text;

namespace RetosMoureDev.Ejercicios
{
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
    public static class Ejercicio0026
    {
        public static void Run()
        {
            ExecuteLogic([(PiedraPapelTijeras.PIEDRA, PiedraPapelTijeras.PIEDRA)]);
            ExecuteLogic([(PiedraPapelTijeras.PIEDRA, PiedraPapelTijeras.TIJERAS)]);
            ExecuteLogic([(PiedraPapelTijeras.PAPEL, PiedraPapelTijeras.TIJERAS)]);
            ExecuteLogic([
                (PiedraPapelTijeras.PIEDRA, PiedraPapelTijeras.PIEDRA),
                (PiedraPapelTijeras.TIJERAS, PiedraPapelTijeras.TIJERAS),
                (PiedraPapelTijeras.PAPEL, PiedraPapelTijeras.PAPEL)
            ]);
            ExecuteLogic([
                (PiedraPapelTijeras.PIEDRA, PiedraPapelTijeras.TIJERAS),
                (PiedraPapelTijeras.TIJERAS, PiedraPapelTijeras.PAPEL),
                (PiedraPapelTijeras.TIJERAS, PiedraPapelTijeras.PIEDRA)
            ]);
            ExecuteLogic([
                (PiedraPapelTijeras.PIEDRA, PiedraPapelTijeras.PAPEL),
                (PiedraPapelTijeras.TIJERAS, PiedraPapelTijeras.PIEDRA),
                (PiedraPapelTijeras.PAPEL, PiedraPapelTijeras.TIJERAS)
            ]);
        }

        private static void ExecuteLogic(List<(PiedraPapelTijeras, PiedraPapelTijeras)> jugadas)
        {
            int victoriasJugador1 = 0;
            int victoriasJugador2 = 0;

            foreach (var jugada in jugadas)
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
            if (victoriasJugador1 == victoriasJugador2)
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
            if (jugada.Item1 == jugada.Item2)
            {
                return PiedraPapelTijerasResultado.TIE;
            }

            if ((jugada.Item1 == PiedraPapelTijeras.PIEDRA && jugada.Item2 == PiedraPapelTijeras.TIJERAS)
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
                resultado.AppendLine($"Juego {juego++}: {ConvertirAUnicode(jugador1)} vs {ConvertirAUnicode(jugador2)}");
            }

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(resultado.ToString());
            Console.OutputEncoding = Encoding.Default;
        }

        private static string ConvertirAUnicode(PiedraPapelTijeras jugada)
        {
            switch (jugada)
            {
                case PiedraPapelTijeras.PIEDRA:
                    return "\u270A";
                case PiedraPapelTijeras.PAPEL:
                    return "\u270B";
                case PiedraPapelTijeras.TIJERAS:
                    return "\u270C";
                default:
                    return "";
            }
        }
    }
}