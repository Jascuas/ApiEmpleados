using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    [Table("Pedidos")]
    public class PedidoDT
    {
        public PedidoDT()
        {
        }

        public PedidoDT(int id_Usuario, double total)
        {
            this.id_Usuario = id_Usuario;
            this.total = total;
        }
        //[Key]
        //[Column("Id_Pedido")]
        //public int id_pedido { get; set; }
        [Column("Id_Usuario")]
        public int id_Usuario { get; set; }
        [Column("Fecha_Pedido")]
        public DateTime fecha_Pedido { get; set; }
        [Column("Total")]
        public double total { get; set; }
        
    }
}
