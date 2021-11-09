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
    public class Usuario : Controller
    {
        private readonly ILogger<Usuario> _logger;
        private readonly ApplicationDbContext _context;

        public Usuario(ILogger<Usuario> logger, ApplicationDbContext context)
        {
            _logger = logger;

            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    

        [HttpPost]
        public IActionResult Registrar(Models.Usuario objMuestra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objMuestra);
                _context.SaveChanges();
                return RedirectToAction("Index", "Usuario");

            }
            
           ViewData["Message"] = "El cliente ha sido registrado";
            return View("ListarUsuario");
        }

        public IActionResult ListarUsuario()
        {
             var lista = _context.listausuarios.ToList();
            return View(lista);
            // return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Usu = await _context.usuario.FindAsync(id);
            if (Usu == null)
            {
                return NotFound();
            }
            return View(Usu);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("nombres,apellidos,dni,direccion,telefono,correo")] Models.Usuario Usu)
        {
            if (id != Usu.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Usu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("ListarUsuario");
        }

        public IActionResult Eliminar(int? id)
        {
            var idusu = _context.usuario.Find(id);
            _context.usuario.Remove(idusu);
            _context.SaveChanges();
            return RedirectToAction("ListarUsuario");
        }
    }
}