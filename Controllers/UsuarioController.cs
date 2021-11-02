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
using Microsoft.AspNetCore.Identity;

namespace hotel_santa_ursula_II.Controllers
{
    public class UsuarioController:Controller
    {
        
        private readonly ApplicationDbContext _context;
       

        public UsuarioController(ApplicationDbContext context)
        {
          _context = context;
        }

           public IActionResult Index()
        {
            return View(_context.usuario.ToList());
        }

        
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(Usuario objMuestra)
        {
            /*if (ModelState.IsValid)
            {*/
                _context.Add(objMuestra);
                _context.SaveChanges();
                ViewData["Message"]= "Su registro se realizó con éxito";
                //return RedirectToAction("Index", "Cliente");

           /* }*/
            return View();
        }
         public IActionResult Editar(int id)
        {
            Usuario objMuestra = _context.usuario.Find(id);
            if(objMuestra == null){
                return NotFound();
            }
            return View(objMuestra);
        }
     

        [HttpPost]
        public IActionResult Editar(int id,[Bind("id,razonsocial,dni,rol,direccion,telefono,Password")] Usuario objMuestra)
        {
             _context.Update(objMuestra);
             _context.SaveChanges();
              ViewData["Message"] = "El contacto se ha actualizado con éxito";
             return View(objMuestra);
        }



    }
}