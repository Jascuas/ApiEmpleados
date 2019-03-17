using ApiOberon.Entities;
using ApiOberon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Data
{
    public interface IOberonContext
    {
        DbSet<UsuarioDTO> Usuario { get; set; }
        DbSet<ProductoDTO> Producto { get; set; }
        DbSet<TallaDTO> Talla { get; set; }
        DbSet<PedidoDTO> Pedidos { get; set; }
        DbSet<ProductoPedidoDTO> ProductosPedido { get; set; }
        int SaveChanges();
    }
}
