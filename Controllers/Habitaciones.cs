using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using hotel_santa_ursula_II.Data;
using hotel_santa_ursula_II.Models;

namespace hotel_santa_ursula_II.Controllers
{
    public class Habitaciones : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        
        public Habitaciones(ApplicationDbContext context,  UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Mostrar()
        {
            var habitacionesm = from o in _context.habitaciones select o;
            return View(await habitacionesm.ToListAsync());
        }
        public async Task<IActionResult> Detalles(int? id)
        {
            Models.Habitaciones objProduct = await _context.habitaciones.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public ActionResult Agregar()
    {
        
            return RedirectToAction("Seleccionar", "Reservas");
        
    }

        [HttpPost]
        public IActionResult Registrar(Models.Habitaciones objMuestra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objMuestra);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Index", objMuestra);
        }
    }
}