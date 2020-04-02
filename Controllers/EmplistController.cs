using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appveyorwebapidemo.Models;

namespace appveyorwebapidemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplistController : ControllerBase
    {
        private readonly KgislDBContext _context;

        public EmplistController(KgislDBContext context)
        {
            _context = context;
        }

        // GET: api/Emplists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emplist>>> GetEmplistItems()
        {
            return await _context.Emplists.ToListAsync();
        }

        // GET: api/Emplists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emplist>> GetEmplist(long id)
        {
            var emplist = await _context.Emplists.FindAsync(id);

            if (emplist == null)
            {
                return NotFound();
            }

            return emplist;
        }

        // PUT: api/Emplists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putemplist(long id, Emplist emplist)
        {
            if (id != emplist.Id)
            {
                return BadRequest();
            }

            _context.Entry(emplist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmplistExists(id))
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

        // POST: api/Emplists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Emplist>> PostEmplist(Emplist emplist)
        {
            _context.Emplists.Add(emplist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmplist", new { id = emplist.Id }, emplist);
        }

        // DELETE: api/Emplists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Emplist>> DeleteEmplist(long id)
        {
            var emplist = await _context.Emplists.FindAsync(id);
            if (emplist == null)
            {
                return NotFound();
            }

            _context.Emplists.Remove(emplist);
            await _context.SaveChangesAsync();

            return emplist;
        }

        private bool EmplistExists(long id)
        {
            return _context.Emplists.Any(e => e.Id == id);
        }
    }
}