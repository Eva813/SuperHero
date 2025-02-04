using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // move superHeroes to the top of the method
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
                { Id = 1, Name = "Superman", FirstName = "Clark", LastName = "Kent", Place = "Metropolis" },
            new SuperHero
                { Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" }
        };
        // GET: api/SuperHero   
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            // var superHeroes = new List<SuperHero>
            // {
            //     new SuperHero
            //         { Id = 1, Name = "Superman", FirstName = "Clark", LastName = "Kent", Place = "Metropolis" },
            //     new SuperHero
            //         { Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" }
            // };
            return Ok(superHeroes);
        }

        // make a get method that returns a single hero by id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = superHeroes.FirstOrDefault(hero => hero.Id == id);
            if (hero == null)
            {
                return BadRequest("No hero found with that id");
            }
            return Ok(hero);
        }

        // make a post method
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        // make a put method that updates a hero by id
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var heroToUpdate = superHeroes.FirstOrDefault(h => h.Id == hero.Id);
            if (heroToUpdate == null)
            {
                return BadRequest("No hero found with that id");
            }
            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;
            return Ok(superHeroes);
        }

        // make a delete method that deletes a hero by id   
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var heroToDelete = superHeroes.FirstOrDefault(h => h.Id == id);
            if (heroToDelete == null)
            {
                return BadRequest("No hero found with that id");
            }
            superHeroes.Remove(heroToDelete);
            return Ok(superHeroes);
        }
    }
}