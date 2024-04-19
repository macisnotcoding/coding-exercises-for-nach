namespace RetosMoureDev.Models.Pokemons
{
    public class PokemonTabla(PokemonTipo superEfectivo, PokemonTipo pocoEfectivo)
    {
        public PokemonTipo SuperEfectivo { get; set; } = superEfectivo;
        public PokemonTipo PocoEfectivo { get; set; } = pocoEfectivo;
    }
}