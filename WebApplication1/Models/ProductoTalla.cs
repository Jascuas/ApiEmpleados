﻿using System;
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
            this.stock = generarStock();
        }
        public Producto producto { get; set; }
        public List<Talla> tallas { get; set; }
        public int stock { get; set; }
        public int generarStock()
        {
            foreach (Talla t in tallas)
            {
                this.stock += t.Stock;
            }
            return stock;
        }
        
    }
}
