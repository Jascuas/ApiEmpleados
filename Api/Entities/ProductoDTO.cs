using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    [Table("PRODUCTOS")]
    public class ProductoDTO 
    {
        [Key]
        [Column("ID_PRODUCTO")]
        public int? Id_Producto { get; set; }
        [Column("PRODUCTO")]
        [Required(ErrorMessage = "Necesita un nombre de producto.")]
        public String Nombre { get; set; }
        [Column("COLOR")]
        [Required(ErrorMessage = "Necesita un color de producto.")]
        public String Color { get; set; }
        [Column("TIPO")]
        [Required(ErrorMessage = "Necesita un tipo de producto.")]
        public String Tipo { get; set; }
        [Column("PRECIO")]
        [Required(ErrorMessage = "Necesita un precio de producto.")]
        public double? Precio { get; set; }
        [Column("INFORMACION")]
        [Required(ErrorMessage = "Necesita informacion de producto.")]
        public String Informacion { get; set; }
        [Column("IMAGEN")]
        [Required(ErrorMessage = "Necesita una imagen de producto.")]
        public String Imagen { get; set; }
        [Column("ESTADO")]
        [Required(ErrorMessage = "Necesita un estado de producto.")]
        public String Estado { get; set; }
        [Column("DETALLES")]
        [Required(ErrorMessage = "Necesita los detalles del producto.")]
        public String Detalles { get; set; }
        public ProductoDTO(string nombre, string color, string tipo, double precio, string informacion, string imagen, string estado, string detalles)
        {
            Nombre = nombre;
            Color = color;
            Tipo = tipo;
            Precio = precio;
            Informacion = informacion;
            Imagen = imagen;
            Estado = estado;
            Detalles = detalles;
        }

        public ProductoDTO()
        {
        }

        public virtual List<TallaDTO> tallas { get; set; }
    }
}
