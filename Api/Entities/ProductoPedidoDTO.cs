using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    [Table("Productos_Pedido")]
    public class ProductoPedidoDTO
    {
        [Key]
        [Column("Id_Producto_Pedido")]
        public int? Id_Producto_Pedido { get; set; }
        [Column("Id_Pedido")]
        public int? Id_Pedido { get; set; }
        [Column("Id_Producto")]
        public int? Id_Producto { get; set; }
        [Column("Unidades")]
        public int? Unidades { get; set; }
        [Column("Size")]
        public String Size { set; get; }
        public virtual ProductoDTO Producto { get; set; }
        public ProductoPedidoDTO()
        {
        }

    }
}
