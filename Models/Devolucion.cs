using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_santa_ursula_II.Models
{
    [Table("t_devolucion")]
    public class Devolucion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Display(Name = "Nombres: ")]
        [Column("nombres")]
        public string nombres { get; set; }

        [Display(Name = "Apellidos: ")]
        [Column("apellidos")]
        public string apellidos { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un DNI")]
        [Display(Name = "DNI: ")]
        [Column("dni")]
        public int dni { get; set; }

        [Display(Name = "Motivo de devolucion: ")]
        [Column("motivo")]
        public string motivo { get; set; }

        [Display(Name = "NUmero de habitacion: ")]
        [Column("numero")]
        public int numero { get; set; }

        public String Estado { get; set; } = "PENDIENTE";
        
    }
}