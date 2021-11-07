using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_santa_ursula_II.Models
{
    //CARRITO
    [Table("t_proforma")]
    public class Carrito
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public String UserID {get; set;}
        public Habitaciones habitacion {get; set;}
        public int Quantity{get; set;}
        public Double Precio { get; set; }
        public String Status { get; set; } = "PENDIENTE";
    }
}