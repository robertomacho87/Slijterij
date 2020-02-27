using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slijterij.DAL;
using Slijterij.Models;

namespace Slijterij.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfWhiskeyController : ControllerBase
    {
        private readonly WhiskeyContext _context;

        public TypeOfWhiskeyController(WhiskeyContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfWhiskey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfWhiskey>>> GetTypesOfWhiskey()
        {
            return await _context.TypesOfWhiskey.ToListAsync();
        }

        // GET: api/TypeOfWhiskey/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfWhiskey>> GetTypeOfWhiskey(int id)
        {
            var typeOfWhiskey = await _context.TypesOfWhiskey.FindAsync(id);

            if (typeOfWhiskey == null)
            {
                return NotFound();
            }

            return typeOfWhiskey;
        }

        // PUT: api/TypeOfWhiskey/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfWhiskey(int id, TypeOfWhiskey typeOfWhiskey)
        {
            if (id != typeOfWhiskey.ID)
            {
                return BadRequest();
            }

            _context.Entry(typeOfWhiskey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfWhiskeyExists(id))
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

        // POST: api/TypeOfWhiskey
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TypeOfWhiskey>> PostTypeOfWhiskey(TypeOfWhiskey typeOfWhiskey)
        {
            _context.TypesOfWhiskey.Add(typeOfWhiskey);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTypeOfWhiskey), new { id = typeOfWhiskey.ID }, typeOfWhiskey);
        }

        // DELETE: api/TypeOfWhiskey/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeOfWhiskey>> DeleteTypeOfWhiskey(int id)
        {
            var typeOfWhiskey = await _context.TypesOfWhiskey.FindAsync(id);
            if (typeOfWhiskey == null)
            {
                return NotFound();
            }

            _context.TypesOfWhiskey.Remove(typeOfWhiskey);
            await _context.SaveChangesAsync();

            return typeOfWhiskey;
        }

        private bool TypeOfWhiskeyExists(int id)
        {
            return _context.TypesOfWhiskey.Any(e => e.ID == id);
        }
    }
}
