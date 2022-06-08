using Microsoft.IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCFirst.Models;
using System.Diagnostics;
using System.Security.Claims;
using Finanzas.Model;
using Finanzas.Data;
using Newtonsoft.Json;

namespace Finanzas.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        private readonly ILogger<HomeController> _logger;
        public Usuario _usuario;
        public Cuenta _Cuenta;
        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                var sessionUser = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("SessionUser"));
                _usuario = _db.usuarios.Find(sessionUser.Id);
                _Cuenta = _db.cuenta.Where(c => c.usuario.Id == sessionUser.Id).FirstOrDefault();
                ViewData["cuenta"] = _Cuenta;
                ViewData["user"] = _usuario;
                return View();
            }
            return RedirectToAction("Index", "Acceso");
        }
        //[Authorize(Roles = "Administrador")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
