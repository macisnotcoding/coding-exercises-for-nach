using RetosMoureDev.Models.Pokemons;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que calcule el daño de un ataque durante
    /// una batalla Pokémon.
    /// - La fórmula será la siguiente: daño = 50 * (ataque / defensa) * efectividad
    /// - Efectividad: x2 (súper efectivo), x1 (neutral), x0.5 (no es muy efectivo)
    /// - Sólo hay 4 tipos de Pokémon: Agua, Fuego, Planta y Eléctrico 
    ///   (buscar su efectividad)
    /// - El programa recibe los siguientes parámetros:
    ///  - Tipo del Pokémon atacante.
    ///  - Tipo del Pokémon defensor.
    ///  - Ataque: Entre 1 y 100.
    ///  - Defensa: Entre 1 y 100.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio <br/>
    /// <a href="https://easycdn.es/1/imagenes/pokemaster_343217.jpg">Tabla de tipos</a>
    /// </remarks>
    public static class Ejercicio0036
    {
        private static readonly Dictionary<PokemonTipo, PokemonTabla> PokemonTipoTabla = new()
        {
            {PokemonTipo.AGUA, new PokemonTabla(PokemonTipo.FUEGO, PokemonTipo.PLANTA) },
            {PokemonTipo.FUEGO, new PokemonTabla(PokemonTipo.PLANTA, PokemonTipo.AGUA) },
            {PokemonTipo.PLANTA, new PokemonTabla(PokemonTipo.AGUA, PokemonTipo.FUEGO) },
            {PokemonTipo.ELECTRICO, new PokemonTabla(PokemonTipo.AGUA, PokemonTipo.PLANTA) }
        };

        public class PokemonException(string message) : Exception(message)
        {
        }

        public static void Run()
        {
            ExecuteLogic(PokemonTipo.AGUA, PokemonTipo.FUEGO, 50, 30);
            Console.WriteLine(new string('=', 40));
            ExecuteLogic(PokemonTipo.AGUA, PokemonTipo.FUEGO, 101, -10);
            Console.WriteLine(new string('=', 40));
            ExecuteLogic(PokemonTipo.FUEGO, PokemonTipo.AGUA, 50, 30);
            Console.WriteLine(new string('=', 40));
            ExecuteLogic(PokemonTipo.FUEGO, PokemonTipo.FUEGO, 50, 30);
            Console.WriteLine(new string('=', 40));
            ExecuteLogic(PokemonTipo.PLANTA, PokemonTipo.ELECTRICO, 30, 50);
        }

        private static void ExecuteLogic(PokemonTipo tipoAtacante, PokemonTipo tipoDefensor, int ataque, int defensa)
        {
            try
            {
                Console.WriteLine($"¡POKE-COMBATE! El pokemon tipo {tipoAtacante}({ataque}) ataca al pokemon tipo {tipoDefensor}({defensa})");
                VerificarParametrosCombate(ataque, defensa);

                double efectividad = CalcularEfectividad(tipoAtacante, tipoDefensor);
                double damage = CalcularDamageAtaque(ataque, defensa, efectividad);

                if (efectividad == PokemonEfectividad.SuperEfectivo)
                {
                    Console.WriteLine("!Es super eficaz!");
                }
                else if (efectividad == PokemonEfectividad.PocoEfectivo)
                {
                    Console.WriteLine("No es muy eficaz...");
                }
                Console.WriteLine($"Se ha hecho {damage} de daño al pokemon tipo {tipoDefensor}");
            }
            catch(PokemonException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void VerificarParametrosCombate(int ataque, int defensa)
        {
            if(ataque <= 0 || ataque > 100 || defensa <= 0 || defensa > 100)
            {
                throw new PokemonException("El ataque o la defensa contiene un valor incorrecto");
            }
        }

        private static double CalcularEfectividad(PokemonTipo tipoAtacante, PokemonTipo tipoDefensor)
        {
            var pokemonTipoTabla = PokemonTipoTabla[tipoAtacante];
            if (pokemonTipoTabla.SuperEfectivo == tipoDefensor)
            {
                return PokemonEfectividad.SuperEfectivo;
            }
            else if (pokemonTipoTabla.PocoEfectivo == tipoDefensor || tipoAtacante == tipoDefensor)
            {
                return PokemonEfectividad.PocoEfectivo;
            }
            else
            {
                return PokemonEfectividad.Neutral;
            }
        }

        private static double CalcularDamageAtaque(int ataque, int defensa, double efectividad)
        {
            return 50 * (ataque / defensa) * efectividad;
        }
    }
}