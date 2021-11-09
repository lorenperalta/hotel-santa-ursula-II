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
       /* public IActionResult Mostrar()
        {
             var resultado=_context.habitaciones.Where(x=>x.disponible==true).ToList();
            var habitacionesm = from o in _context.habitaciones select o;
            return View(resultado);
            
        }*/

        public async Task<IActionResult> Mostrar()
        {
            var habitaciones = from o in _context.habitaciones select o;
            return View(await habitaciones.ToListAsync());
        }

        public async Task<IActionResult> Detalles(int? id)
        {
            Models.Habitaciones objProduct = await _context.habitaciones.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Seleccionar(int? id)
        {
               var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Habitaciones> productos = new List<Habitaciones>();
                return  View("Index",productos);
            }else{
                var producto = await _context.habitaciones.FindAsync(id);
                Carrito proforma = new Carrito();
                proforma.habitacion = producto;// revisar exactamente esto
                proforma.Precio = producto.precio;
                proforma.Quantity = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return  RedirectToAction("Mostrar","Habitaciones");
            }
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
         public async Task<IActionResult> Detalle(int? id)
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
            return  RedirectToAction("Seleccionar","Reservas", new {id});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id,idtipo,numero,precio,descripcion,nivel,Estado,Imagen")] Models.Habitaciones Hab)
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