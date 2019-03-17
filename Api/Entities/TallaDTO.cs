using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    [Table("Tallas")]
    public class TallaDTO
    {
        [Key]
        [Column("Id_Talla")]
        public int? Id_Talla { get; set; }
        [Column("Id_Producto")]
        [Required(ErrorMessage = "Necesita un Id de Producto.")]
        public int? Id_Producto { get; set; }
        [Column("Talla")]
        [Required(ErrorMessage = "Necesita una talla.")]
        public String Size { get; set; }
        [Column("Stock")]
        [Required(ErrorMessage = "Necesita un stock.")]
        public int? Stock { get; set; }

        public TallaDTO()
        {
        }
        public TallaDTO(int id_Talla, int id_Producto, string size, int stock)
        {
            Id_Talla = id_Talla;
            Id_Producto = id_Producto;
            Size = size;
            Stock = stock;
        }
    }
}
