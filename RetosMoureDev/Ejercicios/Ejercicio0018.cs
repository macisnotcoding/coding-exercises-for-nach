using RetosMoureDev.Models;
using System.Text.RegularExpressions;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que evalúe si un/a atleta ha superado correctamente una
    /// carrera de obstáculos.
    /// - La función recibirá dos parámetros:
    ///      - Un array que sólo puede contener String con las palabras
    ///        "run" o "jump"
    ///      - Un String que represente la pista y sólo puede contener "_" (suelo)
    ///        o "|" (valla)
    /// - La función imprimirá cómo ha finalizado la carrera:
    ///      - Si el/a atleta hace "run" en "_" (suelo) y "jump" en "|" (valla)
    ///        será correcto y no variará el símbolo de esa parte de la pista.
    ///      - Si hace "jump" en "_" (suelo), se variará la pista por "x".
    ///      - Si hace "run" en "|" (valla), se variará la pista por "/".
    /// - La función retornará un Boolean que indique si ha superado la carrera.
    /// Para ello tiene que realizar la opción correcta en cada tramo de la pista.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0018
    {
        public static void Run()
        {
            ExecuteLogic([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
            ExecuteLogic([AccionAtleta.run, AccionAtleta.run, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
            ExecuteLogic([AccionAtleta.run, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
            ExecuteLogic([AccionAtleta.run, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.run], "_|_|_|_");
            ExecuteLogic([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump], "_|_|_");
            ExecuteLogic([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run], "_|_|_");
            ExecuteLogic([AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump], "|||||");
            ExecuteLogic([AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump, AccionAtleta.jump], "||?||");
            ExecuteLogic([AccionAtleta.run, AccionAtleta.jump, AccionAtleta.run, AccionAtleta.jump, "aaa"], "_|_|_");
        }

        private static void ExecuteLogic(string[] acciones, string pista)
        {
            if (!SonAccionesValida(acciones))
            {
                Console.WriteLine("Error: las acciones recibidas contiene más instrucciones aparte de las válidas \"run\" y \"jump\"");
            }
            else if (!EsPistaValida(pista))
            {
                Console.WriteLine($"Error: la pista {pista} no es valida");
            }
            else
            {
                string pistaResultante = string.Empty;
                int maxIndice = Math.Max(acciones.Length, pista.Length); //Obtenemos el indice mas grande de entre el numero de acciones y el numero de obstaculos en la pista

                //Recorremos cada paso en la pista y en las acciones del atleta
                for (int i = 0; i < maxIndice; i++)
                {
                    //Si el indice es mayor o igual al numero de acciones o al numero de obstaculos en la pista
                    //añadimos un '?' a la pista resultante
                    if (i >= acciones.Length || i >= pista.Length)
                    {
                        pistaResultante += '?';
                        continue;
                    }

                    //Si el atleta corre en el suelo y salta la valla, no cambiamos la pista
                    //Si el atleta salta en el suelo, cambiamos la pista por 'x'
                    //Si el atleta corre en la valla, cambiamos la pista por '/'
                    if (acciones[i] == "run")
                    {
                        pistaResultante += pista[i] == '_' ? pista[i] : '/';
                    }
                    else
                    {
                        pistaResultante += pista[i] == '|' ? pista[i] : 'x';
                    }
                }

                Console.WriteLine($"La pista \"{pista}\" ha quedado asi tras el paso del atleta: \"{pistaResultante}\"");
                bool haSuperadoLaCarrera = pista == pistaResultante;
                Console.WriteLine($"El atleta {(haSuperadoLaCarrera ? "SI" : "NO")} ha superado la carrera");
            }
        }

        private static bool SonAccionesValida(string[] acciones)
        {
            return acciones.All(accion => accion == "run" || accion == "jump");
        }

        private static bool EsPistaValida(string pista)
        {
            return Regex.IsMatch(pista, "^[_|]*$");
        }
    }
}