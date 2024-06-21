using ReviewAppAPI.Model;

namespace ReviewAppAPI.Interfaces
{
    public interface IPokemonRepository
    {
        object GetPokemon(int pokeId);
        ICollection<Pokemon> GetPokemons(int pokeId);
        object GetPokemons();
        bool PokemonExist(int pokeId);
    }
}
