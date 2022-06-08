using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finanzas.Data;
using Finanzas.Model;
using Finanzas.Model.VM;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace Finanzas.Controllers
{
    public class TransaccionsController : Controller
    {
        private readonly AppDbContext _context;

        public TransaccionsController(AppDbContext context)
        {
            _context = context;

        }


        // GET: Transaccions
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                return _context.transaccion != null ?
                          View(await _context.transaccion.Where(t => t.cuenta.usuario.Id == sessionUser.Id ).Include(c => c.categoria).ToListAsync()) :
                          Problem("Entity set 'AppDbContext.transaccion'  is null.");
            }
            return RedirectToAction("Index", "Acceso");
            
        }

        // GET: Transaccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.transaccion == null)
            {
                return NotFound();
            }

            var transaccion = await _context.transaccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // GET: Transaccions/Create
        public IActionResult Create()
        {
            List<SelectListItem> opciones = new List<SelectListItem>();
            var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
            opciones = _context.categoria.Where(c => c.UsuarioId == sessionUser.Id).Select(a =>
                                                new SelectListItem
                                                {
                                                    Value = a.Id.ToString(),
                                                    Text = a.Nombre
                                                }).ToList();
            ViewBag.opciones = opciones;
            return View();
        }

        // POST: Transaccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("Id,Fecha,Monto,Detalle")]
        public async Task<IActionResult> Create([Bind("Transaccion")] TransaccionVM transaccionVM)
        {
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                //buscamos la categoria
                transaccionVM.Transaccion.categoria = _context.categoria.Find(transaccionVM.Transaccion.categoria.Id);
                // buscamos la cuenta del cliente
                var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                transaccionVM.Transaccion.cuenta = _context.cuenta.Where(c => c.usuario.Id == sessionUser.Id).FirstOrDefault();

                _context.Add(transaccionVM.Transaccion);
                await _context.SaveChangesAsync();

                IEnumerable<Transaccion> listTransacciones = _context.transaccion.Where(t => t.cuenta.usuario.Id == sessionUser.Id).Include(a => a.cuenta).ToList();

                float cont = 0;
                foreach (Transaccion trt in listTransacciones)
                {
                    if (trt.tipo == "I")
                    {
                        cont += trt.Monto;
                    }
                    else
                    {
                        cont -= trt.Monto;
                    }
                }
                transaccionVM.Transaccion.cuenta.Saldo = cont;
                _context.Update(transaccionVM.Transaccion.cuenta);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Acceso");            


            //if (ModelState.IsValid)
            //{
            //    _context.Add(transaccionVM.Transaccion);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(transaccionVM.Transaccion);
        }

        // GET: Transaccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.transaccion == null)
            {
                return NotFound();
            }
            TransaccionVM transaccionVM = new TransaccionVM();
            transaccionVM.Transaccion = await _context.transaccion.FindAsync(id);
            if (transaccionVM.Transaccion == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                List<SelectListItem> opciones = new List<SelectListItem>();
                var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                opciones = _context.categoria.Where(c => c.UsuarioId == sessionUser.Id).Select(a =>
                                                    new SelectListItem
                                                    {
                                                        Value = a.Id.ToString(),
                                                        Text = a.Nombre
                                                    }).ToList();
                ViewBag.opciones = opciones;

                return View(transaccionVM);
            }
            return RedirectToAction("Index", "Acceso");
           
        }

        // POST: Transaccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Transaccion")] TransaccionVM transaccionVM)
        {
            if (id != transaccionVM.Transaccion.Id)
            {
                return NotFound();
            }

            try
            {
                if (HttpContext.Session.GetString("SessionUser") != null)
                {
                    var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                    transaccionVM.Transaccion.cuenta = _context.cuenta.Where(c => c.usuario.Id == sessionUser.Id).FirstOrDefault();
                    transaccionVM.Transaccion.categoria = _context.categoria.Find(transaccionVM.Transaccion.categoria.Id);
                    _context.Update(transaccionVM.Transaccion);
                    await _context.SaveChangesAsync();

                    IEnumerable<Transaccion> listTransacciones = _context.transaccion.Where(t => t.cuenta.usuario.Id == sessionUser.Id).Include(a => a.cuenta).ToList();

                    float cont = 0;
                    foreach (Transaccion trt in listTransacciones)
                    {
                        if (trt.tipo == "I")
                        {
                            cont += trt.Monto;
                        }
                        else
                        {
                            cont -= trt.Monto;
                        }
                    }
                    transaccionVM.Transaccion.cuenta.Saldo = cont;
                    _context.Update(transaccionVM.Transaccion.cuenta);
                    await _context.SaveChangesAsync();
                }
                else { return RedirectToAction("Index", "Acceso"); }
                
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionExists(transaccionVM.Transaccion.Id))
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

        // GET: Transaccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.transaccion == null)
            {
                return NotFound();
            }

            var transaccion = await _context.transaccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transaccion == null)
            {
                return Problem("Entity set 'AppDbContext.transaccion'  is null.");
            }
            var transaccion = await _context.transaccion.FindAsync(id);
            if (transaccion != null)
            {
                _context.transaccion.Remove(transaccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionExists(int id)
        {
          return (_context.transaccion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
