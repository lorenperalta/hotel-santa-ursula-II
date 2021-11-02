using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using hotel_santa_ursula_II.Data;
using hotel_santa_ursula_II.Models;
namespace hotel_santa_ursula_II.Controllers
{
    public class Habitaciones : Controller
    {
        private readonly ILogger<Habitaciones> _logger;
        private readonly ApplicationDbContext _context;

        public Habitaciones(ILogger<Habitaciones> logger, ApplicationDbContext context)
        {
            _logger = logger;

            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Mostrar()
        {
            var lista = _context.habitaciones.ToList();
            return View(lista);
        }
        public IActionResult Listar()
        {
            var lista = _context.habitaciones.ToList();
            return View(lista);
            // return View();
        }
         public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vtiphab = await _context.habitaciones.FindAsync(id);
            if (vtiphab == null)
            {
                return NotFound();
            }
            return View(vtiphab);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id,idtipo,numero,precio,descripcion,nivel,disponible,Imagen")] Models.Habitaciones Hab)
        {
            if (id != Hab.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Hab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Listar");
        }


        [HttpPost]
        public IActionResult Registrar(Models.Habitaciones objMuestra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objMuestra);
                _context.SaveChanges();
                return RedirectToAction("Mostrar");

            }
            return View("Index", objMuestra);
        }
         public IActionResult Eliminar(int? id)
        {
            var etiphab = _context.habitaciones.Find(id);
            _context.habitaciones.Remove(etiphab);
            _context.SaveChanges();
            return RedirectToAction("Listar");
        }

    }
}