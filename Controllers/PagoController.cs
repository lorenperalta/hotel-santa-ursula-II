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

namespace hotel_santa_ursula_II.Controllers
{
    public class PagoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PagoController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Create(Decimal monto)
        {
            Pago pago = new Pago();
            pago.UserID = _userManager.GetUserName(User);
            pago.MontoTotal = monto;
            return View(pago);
        }

        [HttpPost]
        public IActionResult Pagar(Pago pago)
        {
            pago.FechaPago = DateTime.Now;
            _context.Add(pago);

            var itemsReserva = from o in _context.DataReservas select o;
            itemsReserva = itemsReserva.
                Include(p => p.Habitaciones).
                Where(s => s.UserID.Equals(pago.UserID) && s.Estado.Equals("PENDIENTE"));

            Pedido pedido = new Pedido();
            pedido.UserID = pago.UserID;
            pedido.Total = pago.MontoTotal;
            pedido.pago = pago;
            pedido.Estado = "PENDIENTE";
            _context.Add(pedido);


            List<Detallepedido> itemsPedido = new List<Detallepedido>();
            foreach(var item in itemsReserva.ToList()){
                Detallepedido detallePedido = new Detallepedido();
                detallePedido.pedido=pedido;
                detallePedido.Precio = Convert.ToInt32(item.Precio);
                detallePedido.Habitaciones = item.Habitaciones;
                detallePedido.Cantidad = item.CantHuespedes;
                itemsPedido.Add(detallePedido);
            }

            _context.AddRange(itemsPedido);

            foreach (Reservas p in itemsReserva.ToList())
            {
                p.Estado="PROCESADO";
            }
            _context.UpdateRange(itemsReserva);

            _context.SaveChanges();

            ViewData["Message"] = "El pago se ha registrado";
            return View("Create");
        }

    }
}