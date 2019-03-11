using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    public class ProductoTallaDT
    {
        public ProductoTallaDT(ProductoDT producto, List<TallaDT> tallas)
        {
            this.producto = producto;
            this.tallas = tallas;
            this.stock = generarStock();
        }
        public ProductoDT producto { get; set; }
        public List<TallaDT> tallas { get; set; }
        public int stock { get; set; }
        public int generarStock()
        {
            foreach (TallaDT t in tallas)
            {
                this.stock += t.Stock;
            }
            return stock;
        }
        
    }
}
