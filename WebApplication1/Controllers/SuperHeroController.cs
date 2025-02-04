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
        // GET: api/SuperHero   
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var superHeroes = new List<SuperHero>
            {
                new SuperHero
                    { Id = 1, Name = "Superman", FirstName = "Clark", LastName = "Kent", Place = "Metropolis" },
                new SuperHero
                    { Id = 2, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" }
            };
            return Ok(superHeroes);
        }
    }
}