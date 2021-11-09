using System;
using System.Threading.Tasks;
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
        

        public string numero { get; set; }

        public int precio { get; set; }
        public string descripcion { get; set; }

        public int nivel { get; set; }
        
        public string Estado { get; set; }
        public string Imagen { get; set; }
        
        public TipoHabitacion tipoHabitacion { get; set; }

    }
}