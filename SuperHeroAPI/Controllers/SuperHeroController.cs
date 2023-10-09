using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero>  superHeroes = new List<SuperHero>
            {
                new SuperHero {Id = 1, Name= "Spider Man", FirstName="Peter",
                    LastName="Parker",Place="New York"},
                new SuperHero {Id = 2, Name= "Iron Man", FirstName="Tony",
                    LastName="Stark",Place="New York"},
                new SuperHero {Id = 3, Name= "Hulk", FirstName="Peter",
                    LastName="Jenner",Place="DC"},
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {

            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetsingleHero(int id)
        {
           var hero = superHeroes.Find(x => x.Id == id);
            if(hero == null)
            {
               return  NotFound("Sorry, but this hero does not exist");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, but this hero does not exist");
            }
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            return Ok(superHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, but this hero does not exist");
            }
            superHeroes.Remove(hero);    

            return Ok(superHeroes);
        }
    }
}
