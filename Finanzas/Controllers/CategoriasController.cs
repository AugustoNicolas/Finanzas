using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finanzas.Data;
using Finanzas.Model;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Finanzas.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                return _context.categoria != null ?
                              View(await _context.categoria.Where(c => c.UsuarioId == sessionUser.Id).ToListAsync()) :
                              Problem("Entity set 'AppDbContext.categoria'  is null.");
            }
            return RedirectToAction("Index", "Acceso");
            
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                var categoria = await _context.categoria.Where(c => c.UsuarioId == sessionUser.Id)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (categoria == null)
                {
                    return NotFound();
                }

                return View(categoria);
            }
            return RedirectToAction("Index", "Acceso");
            
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Cod")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("SessionUser") != null)
                {
                    var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                    categoria.UsuarioId = sessionUser.Id;
                    _context.Add(categoria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Index", "Acceso");
                
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cod")] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (HttpContext.Session.GetString("SessionUser") != null)
                    {
                        var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                        categoria.UsuarioId = sessionUser.Id;
                        _context.Update(categoria);
                        await _context.SaveChangesAsync();
                    }
                    else { return RedirectToAction("Index", "Acceso"); }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categoria == null)
            {
                return Problem("Entity set 'AppDbContext.categoria'  is null.");
            }
            var categoria = await _context.categoria.FindAsync(id);
            if (categoria != null)
            {
                _context.categoria.Remove(categoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
          return (_context.categoria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
