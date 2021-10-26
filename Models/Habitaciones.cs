using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_santa_ursula_II.Models
{
    [Table("T_habitaciones")]
    public class Habitaciones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Display(Name = "Tipo de habitacion: ")]
        [Column("idtipo")]
        public int idtipo { get; set; }

        [Required(ErrorMessage = "Numero de habitacion")]
        [Display(Name = "Numero de habitacion: ")]
        [Column("numero")]
        public string numero { get; set; }

        [Required(ErrorMessage = "precio")]
        [Display(Name = "Precio: ")]
        [Column("precio")]
        public double precio { get; set; }

        [Required(ErrorMessage = "Descripcion")]
        [Display(Name = "Descripcion: ")]
        [Column("descripcion")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Nivel")]
        [Display(Name = "Nivel: ")]
        [Column("nivel")]
        public int nivel { get; set; }
        [Required(ErrorMessage = "disponible")]
        [Display(Name = "disponible: ")]
        [Column("disponible")]
        public bool disponible { get; set; }

        [Required(ErrorMessage = "Imagen")]
        [Display(Name = "Imagen(URL): ")]
        [Column("Imagen")]
        public string Imagen { get; set; }
    }
}