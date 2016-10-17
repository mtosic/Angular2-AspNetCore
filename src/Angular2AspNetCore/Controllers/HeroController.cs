using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular2AspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private GotContext db;

        public HeroController(GotContext context)
        {
            db = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var heroes = db.Heroes.ToList();
            return Ok(heroes);
        }

        [HttpGet("Dead")]
        public IActionResult GetDead()
        {
            var heroes = db.Heroes.Where(x => x.IsDead == true).ToList();
            return Ok(heroes);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hero = db.Heroes.Where(x => x.Id == id).SingleOrDefault();
            return Ok(hero);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Hero hero)
        {
            var newHero = db.Heroes.Add(hero);
            db.SaveChanges();
            return Ok(newHero.Entity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Hero hero)
        {
            var existingHero = db.Heroes.Where(x => x.Id == id).SingleOrDefault();
            existingHero.Name = hero.Name;
            existingHero.IsDead = hero.IsDead;
            db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroToDelete = db.Heroes.Where(x => x.Id == id).SingleOrDefault();
            db.Heroes.Remove(heroToDelete);
            db.SaveChanges();
        }
    }
}
