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
    public class CuentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CuentasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cuentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuenta>>> Getcuenta()
        {
          if (_context.cuenta == null)
          {
              return NotFound();
          }
            return await _context.cuenta.Include(x => x.usuario).ToListAsync();
        }

        // GET: api/Cuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> GetCuenta(int id)
        {
          if (_context.cuenta == null)
          {
              return NotFound();
          }
            var cuenta = await _context.cuenta.Include(x => x.usuario).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (cuenta == null)
            {
                return NotFound();
            }

            return cuenta;
        }

        // PUT: api/Cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta(int id, Cuenta cuenta)
        {
            if (id != cuenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
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

        // POST: api/Cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuenta>> PostCuenta(Cuenta cuenta)
        {
          if (_context.cuenta == null)
          {
              return Problem("Entity set 'AppDbContext.cuenta'  is null.");
          }
            _context.cuenta.Add(cuenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuenta", new { id = cuenta.Id }, cuenta);
        }

        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            if (_context.cuenta == null)
            {
                return NotFound();
            }
            var cuenta = await _context.cuenta.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            _context.cuenta.Remove(cuenta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuentaExists(int id)
        {
            return (_context.cuenta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
