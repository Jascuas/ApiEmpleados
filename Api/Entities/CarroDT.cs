using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    public class CarroDT
    {
        public CarroDT(ProductoDT producto,TallaDT talla, int unidades)
        {
            this.Producto = producto;
            this.Talla = talla;
            this.unidades = unidades;
        }
        public TallaDT Talla { get; set; }
        public ProductoDT Producto { get; set; }
        public int unidades { get; set; }
        
    }
}
