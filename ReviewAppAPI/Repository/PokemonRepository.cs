using Microsoft.EntityFrameworkCore;
using ReviewAppAPI.Data;
using ReviewAppAPI.Interfaces;
using ReviewAppAPI.Model;

namespace ReviewAppAPI.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
        public Pokemon GetPokemon(int id)//you can search by id
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }
        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(n => n.Name == name).FirstOrDefault();
        }
        public decimal GetPokemonRating(int pokeID)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeID);
            if(review.Count()<=0) return 0;
            return((decimal)review.Average(r=>r.Rating)) ;
        }

        //public ICollection<Pokemon> GetPokemons()// Get all Pokemons to list
        //{
        //    return _context.Pokemon.OrderBy(p => p.Id).ToList();
        //}

        public ICollection<Pokemon> GetPokemons(int pokeId)
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExist(int pokeID)
        {
           // throw new NotImplementedException();
           return _context.Pokemon.Any(p => p.Id == pokeID);
        }

        object IPokemonRepository.GetPokemon(int pokeId)
        {
            throw new NotImplementedException();
        }

        object IPokemonRepository.GetPokemons()
        {
            throw new NotImplementedException();
        }
    }
}
