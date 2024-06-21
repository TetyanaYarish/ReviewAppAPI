using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ReviewAppAPI.Interfaces;
using ReviewAppAPI.Model;
using ReviewAppAPI.DTO;
using ReviewAppAPI.Interfaces;
using ReviewAppAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ReviewAppAPI.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonController(IPokemonRepository pokemonrepository)
        {
            _pokemonRepository = pokemonrepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
        [HttpGet("{pokeID}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId)) return NotFound();
            var pokemon = _pokemonRepository.GetPokemon(pokeId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState); return Ok(pokemon);

        }
        //[HttpGet("{pokeID/rating}")]
        //[ProducesResponseType(200, Type = typeof(Pokemon))]
        //[ProducesResponseType(400)]
        //public IActionResult GetPokemonRating(int pokeId)
        //{
        //    //if (!_pokemonRepository.PokemonExist(pokeId))
        //    //    return NotFound();
        //    //var rating = _pokemonRepository.GetPokemonRating(pokeId);
        //    //if(!ModelState.IsValid)
        //        return BadRequest(); return Ok(rating);
        //}
    }
    
}
