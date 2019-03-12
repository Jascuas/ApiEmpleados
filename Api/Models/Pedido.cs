using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        [Column("Id_Pedido")]
        public int? id_pedido { get; set; }
        [Column("Id_Usuario")]
        [Required(ErrorMessage = "Necesita un Id de Usuario.")]
        public int? id_Usuario { get; set; }
        [Column("Fecha_Pedido")]
        //[Required(ErrorMessage = "Necesita una fecha de realizacion de pedido.")]
        public DateTime? fecha_Pedido { get; set; }
        [Column("Total")]
        [Required(ErrorMessage = "Necesita un precio total del pedido.")]
        public double? total { get; set; }
        
    }
}
