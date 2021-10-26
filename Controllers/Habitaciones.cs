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