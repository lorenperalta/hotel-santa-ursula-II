using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotel_santa_ursula_II.Data;
using hotel_santa_ursula_II.Models;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;


namespace hotel_santa_ursula_II.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CarritoController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
               // GET: Proforma
        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserName(User);
            var carrito = from o in _context.DataProforma select o;
            carrito = carrito.
                Include(p => p.habitacion).
                Where(s => s.UserID.Equals(userID));
            
            return View(await carrito.ToListAsync());
        }
        
        /****************************************************************************************************/

        // GET: Proforma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var proforma = await _context.DataProforma.FindAsync(id);
            
            _context.DataProforma.Remove(proforma);
            await _context.SaveChangesAsync();
            
           
            return RedirectToAction(nameof(Index));
        }
        
       public IActionResult Editar(int id) {
            var region = _context.DataProforma.Find(id);
            return View(region);
        }

        [HttpPost]
        public IActionResult Editar(Carrito r) {
            if (ModelState.IsValid) {
                var region = _context.DataProforma.Find(r.Id);
                region.Quantity = r.Quantity;
                region.Precio=r.Precio;
                region.C_noches=r.C_noches;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }

        public IActionResult EditarConfirmacion() {
            return View();
        }
         [HttpPost]
        public IActionResult Delete(int id) {
          
            var pro = from o in _context.DataProforma select o;
            pro = pro.Where(n => n.Id.Equals(id));
           
         

            foreach (Models.Carrito a in pro.ToList())
            {
                
              
                 var hab = from o in _context.habitaciones select o;
                    hab = hab.Where(m => m.id.Equals(10));
                    foreach (Models.Habitaciones j in hab.ToList())
                    {
                    
                        j.Estado="Disponible";
                    }
                        _context.UpdateRange(hab);
                        _context.SaveChanges();
            }
            var carrito = _context.DataProforma.Find(id);
                      
       
            _context.Remove(carrito);
            _context.SaveChanges();
            

            return RedirectToAction("Carrito");
        }
    }
}
