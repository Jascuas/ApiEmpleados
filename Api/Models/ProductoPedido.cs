﻿using ApiOberon.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Models
{
    public class ProductoPedido
    {
        public ProductoPedido(int id_producto_pedido, Producto producto, int id_talla, int unidades)
        {
            this.id_producto_pedido = id_producto_pedido;
            this.producto = producto;
            this.id_talla = id_talla;
            this.unidades = unidades;
        }
        public int id_producto_pedido { get; set; }
        public Producto producto { get; set; }
        public int id_talla { get; set; }
        public int unidades { get; set; }
    }
}
