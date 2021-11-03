using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_santa_ursula_II.Models
{
     [Table("L_Reclamaciones")]    
    public class Reclamaciones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        public int Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public int N_Celular { get; set; }
        public string Correo { get; set; }
        public string Reclamo { get; set; }

    }
}