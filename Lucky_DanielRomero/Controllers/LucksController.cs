using Lucky_DanielRomero.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucky_DanielRomero.Models;
using Microsoft.EntityFrameworkCore;

namespace Lucky_DanielRomero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LucksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LucksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Luck>>> GetPeople()
        {
            return await _context.Lucky.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Luck>> GetPerson(int id)
        {
            var person = await _context.Lucky.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Luck person)
        {
            if (id != person.SuerteId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Luck>> PostPerson(Luck person)
        {
            _context.Lucky.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.SuerteId }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Lucky.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Lucky.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Lucky.Any(e => e.SuerteId == id);
        }
    }
}
