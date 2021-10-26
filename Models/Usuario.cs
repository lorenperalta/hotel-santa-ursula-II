using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_santa_ursula_II.Models
{
    [Table("T_usuarios")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Nombre y apellidos / Razon  social")]
        [Display(Name = "Razon social/ nombre: ")]
        [Column("razonsocial")]
        public string razonsocial { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un dni/RUC")]
        [Display(Name = "DNI: ")]
        [Column("dni")]
        public int dni { get; set; }

        [Display(Name = "Cargo: ")]
        [Column("rol")]
        public int rol { get; set; }

        [Display(Name = "Direccion: ")]
        [Column("direccion")]
        public string direccion { get; set; }

        [Display(Name = "Telefono: ")]
        [Column("telefono")]
        public int telefono { get; set; }

        [Display(Name = "Correo: ")]
        [Column("correo")]
        [EmailAddress]
        public string correo { get; set; }
        [Display(Name = "Contraseña: ")]
        [Column("password")]
        //[password]
        public string password { get; set; }
    }
}