﻿using ApiOberon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Data
{
    public interface IOberonContext
    {
        DbSet<Usuario> Usuario { get; set; }
        DbSet<Producto> Producto { get; set; }
        DbSet<Talla> Talla { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<ProductoPedido> ProductosPedido { get; set; }
        int SaveChanges();
    }
}