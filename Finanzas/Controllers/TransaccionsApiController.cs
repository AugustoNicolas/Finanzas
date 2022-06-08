using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Finanzas.Data;
using Finanzas.Model;

namespace Finanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransaccionsApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TransaccionsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> Gettransaccion()
        {
          if (_context.transaccion == null)
          {
              return NotFound();
          }
            return await _context.transaccion.Include(a => a.categoria).Include(a => a.cuenta).Include(a => a.cuenta.usuario).ToListAsync();
        }

        // GET: api/TransaccionsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccion>> GetTransaccion(int id)
        {
          if (_context.transaccion == null)
          {
              return NotFound();
          }
            var transaccion = await _context.transaccion.Include(a => a.categoria).Include(a => a.cuenta).Include(a => a.cuenta.usuario).Where(x => x.Id == id).FirstOrDefaultAsync(); ;

            if (transaccion == null)
            {
                return NotFound();
            }

            return transaccion;
        }

        // PUT: api/TransaccionsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccion(int id, Transaccion transaccion)
        {
            if (id != transaccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionExists(id))
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

        // POST: api/TransaccionsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaccion>> PostTransaccion(Transaccion transaccion)
        {
          if (_context.transaccion == null)
          {
              return Problem("Entity set 'AppDbContext.transaccion'  is null.");
          }
            _context.transaccion.Add(transaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaccion", new { id = transaccion.Id }, transaccion);
        }

        // DELETE: api/TransaccionsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaccion(int id)
        {
            if (_context.transaccion == null)
            {
                return NotFound();
            }
            var transaccion = await _context.transaccion.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }

            _context.transaccion.Remove(transaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("c/{id}")]
        public ActionResult<List<Transaccion>> GetTransaccionUser(int id)
        {
            if (_context.transaccion == null)
            {
                return NotFound();
            }
            var transaccion =  _context.transaccion.Where(t => t.cuenta.usuario.Id == id).Include(a => a.categoria).Include(a => a.cuenta).Include(a => a.cuenta.usuario).ToList();

            if (transaccion == null)
            {
                return NotFound();
            }

            return transaccion;
        }
        private bool TransaccionExists(int id)
        {
            return (_context.transaccion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
