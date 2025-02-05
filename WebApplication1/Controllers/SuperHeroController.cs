using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        // GET: api/SuperHero   
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok( await _context.SuperHeroes.ToListAsync());
        }

        // make a get method that returns a single hero by id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
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
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        // make a put method that updates a hero by id
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            // use EF to update the hero
            // get the hero from the list
            var heroToUpdate = await _context.SuperHeroes.FindAsync(hero.Id);
            if (heroToUpdate == null)
            {
                return BadRequest("No hero found with that id");
            }
            // update the hero
            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.LastName = hero.LastName;
            heroToUpdate.Place = hero.Place;
            // save the changes
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());

            // var heroToUpdate = superHeroes.FirstOrDefault(h => h.Id == hero.Id);
            // if (heroToUpdate == null)
            // {
            //     return BadRequest("No hero found with that id");
            // }
            // heroToUpdate.Name = hero.Name;
            // heroToUpdate.FirstName = hero.FirstName;
            // heroToUpdate.LastName = hero.LastName;
            // heroToUpdate.Place = hero.Place;
            // return Ok(superHeroes);
        }

        // make a delete method that deletes a hero by id   
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            // use EF to delete the hero
            var heroToDelete = await _context.SuperHeroes.FindAsync(id);
            if (heroToDelete == null)
            {
                return BadRequest("No hero found with that id");
            }
            _context.SuperHeroes.Remove(heroToDelete);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());

            // var heroToDelete = superHeroes.FirstOrDefault(h => h.Id == id);
            // if (heroToDelete == null)
            // {
            //     return BadRequest("No hero found with that id");
            // }
            // superHeroes.Remove(heroToDelete);
            // return Ok(superHeroes);
        }
    }
}