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
        public int? id_Producto_Pedido { get; set; }
        [Column("Id_Pedido")]
        public int? id_Pedido { get; set; }
        [Column("Id_Talla")]
        public int? id_Talla { get; set; }
        [Column("Unidades")]
        public int? unidades { get; set; }
        public ProductoPedidoDTO()
        {
        }
        public ProductoPedidoDTO(int id_Talla, int unidades)
        {
            this.id_Talla = id_Talla;
            this.unidades = unidades;
        }
        public virtual TallaDTO Talla { get; set; }

    }
}
