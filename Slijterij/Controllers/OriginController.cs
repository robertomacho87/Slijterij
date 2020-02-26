﻿using System;
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
    public class OriginController : ControllerBase
    {
        private readonly WhiskeyContext _context;

        public OriginController(WhiskeyContext context)
        {
            _context = context;
        }

        // GET: api/Origin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Origin>>> GetOrigins()
        {
            return await _context.Origins.ToListAsync();
        }

        // GET: api/Origin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Origin>> GetOrigin(int id)
        {
            var origin = await _context.Origins.FindAsync(id);

            if (origin == null)
            {
                return NotFound();
            }

            return origin;
        }

        // PUT: api/Origin/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigin(int id, Origin origin)
        {
            if (id != origin.ID)
            {
                return BadRequest();
            }

            _context.Entry(origin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OriginExists(id))
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

        // POST: api/Origin
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Origin>> PostOrigin(Origin origin)
        {
            _context.Origins.Add(origin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrigin", new { id = origin.ID }, origin);
        }

        // DELETE: api/Origin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Origin>> DeleteOrigin(int id)
        {
            var origin = await _context.Origins.FindAsync(id);
            if (origin == null)
            {
                return NotFound();
            }

            _context.Origins.Remove(origin);
            await _context.SaveChangesAsync();

            return origin;
        }

        private bool OriginExists(int id)
        {
            return _context.Origins.Any(e => e.ID == id);
        }
    }
}
