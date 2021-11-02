﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hotel_santa_ursula_II.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<hotel_santa_ursula_II.Models.TipoHabitacion> Tipo_hab { get; set; }
        public DbSet<hotel_santa_ursula_II.Models.Habitaciones> habitaciones { get; set; }
        public DbSet<hotel_santa_ursula_II.Models.Usuario> usuario { get; set; }
        public DbSet<hotel_santa_ursula_II.Models.Reservas> DataReservas { get; set; }
    }
}
