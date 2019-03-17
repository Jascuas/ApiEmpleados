using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Models
{
    public class ProductoTalla
    {
        public ProductoTalla(Producto producto, List<Talla> tallas)
        {
            this.producto = producto;
            this.tallas = tallas;
        }

        public ProductoTalla(Producto producto, List<Talla> tallas, int unidades) : this(producto, tallas)
        {
            this.producto = producto;
            this.tallas = tallas;
            this.unidades = unidades;
        }

        public Producto producto { get; set; }
        public List<Talla> tallas { get; set; }
        public int? unidades { get; set; }
        
    }
}
