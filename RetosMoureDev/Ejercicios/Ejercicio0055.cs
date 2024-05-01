using RetosMoureDev.Models.Tenis;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe un programa que muestre cómo transcurre un juego de tenis y quién lo ha ganado.
    /// El programa recibirá una secuencia formada por "P1" (Jugador 1) o "P2" (Jugador 2), según quien
    /// gane cada punto del juego.
    ///
    /// - Las puntuaciones de un juego son "Love" (cero), 15, 30, 40, "Deuce" (empate), ventaja.
    /// - Ante la secuencia [P1, P1, P2, P2, P1, P2, P1, P1], el programa mostraría lo siguiente:
    ///   15 - Love
    ///   30 - Love
    ///   30 - 15
    ///   30 - 30
    ///   40 - 30
    ///   Deuce
    ///   Ventaja P1
    ///   Ha ganado el P1
    /// - Si quieres, puedes controlar errores en la entrada de datos.
    /// - Consulta las reglas del juego si tienes dudas sobre el sistema de puntos.
    /// </summary>
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0055
    {
        public static void Run()
        {
            ExecuteLogic([Jugador.P1, Jugador.P1, Jugador.P2, Jugador.P2, Jugador.P1, Jugador.P2, Jugador.P1, Jugador.P1]);
            ExecuteLogic([Jugador.P1, Jugador.P1, Jugador.P2, Jugador.P2, Jugador.P1, Jugador.P2, Jugador.P1, Jugador.P1, Jugador.P2, Jugador.P1]);
            ExecuteLogic([Jugador.P1, Jugador.P1, Jugador.P1, Jugador.P1, Jugador.P1, Jugador.P1]);
            ExecuteLogic([Jugador.P1, Jugador.P1]);
        }

        private static void ExecuteLogic(Jugador[] jugadas)
        {
            SimularPartido(jugadas);
        }

        private static void SimularPartido(Jugador[] jugadas)
        {
            string[] estados = ["Love", "15", "30", "40", "Deuce", "Ventaja"];
            int puntuacionP1 = 0;
            int puntuacionP2 = 0;
            bool partidoAcabado = false;
            bool error = false;

            foreach(var jugada in jugadas)
            {
                error = partidoAcabado;

                if (jugada == Jugador.P1)
                    puntuacionP1++;
                else
                    puntuacionP2++;

                if(puntuacionP1 >= 3 && puntuacionP2 >= 3)
                {
                    if(!partidoAcabado && Math.Abs(puntuacionP1 - puntuacionP2) <= 1)
                    {
                        Console.WriteLine(puntuacionP1 == puntuacionP2 ? "Deuce" : (puntuacionP1 > puntuacionP2 ? "Ventaja P1" : "Ventaja P2"));
                    }
                    else
                    {
                        partidoAcabado = true;
                    }
                }
                else
                {
                    if(puntuacionP1 < 4 && puntuacionP2 < 4)
                    {
                        Console.WriteLine($"{estados[puntuacionP1]}-{estados[puntuacionP2]}");
                    }
                    else
                    {
                        partidoAcabado = true;
                    }
                }
            }

            if (error || !partidoAcabado)
            {
                Console.WriteLine("Las jugadas no concuerdan con el final de un partido");
            }
            else
            {
                Console.WriteLine($"Ha ganado el jugador P{(puntuacionP1 > puntuacionP2 ? "1" : "2")}");
            }
        }
    }
}