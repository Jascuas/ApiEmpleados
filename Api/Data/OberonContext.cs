using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ApiOberon.Entities;
using ApiOberon.Models;

namespace ApiOberon.Data
{
    public class OberonContext: DbContext, IOberonContext
    {
        public OberonContext() : base("name=cadenaoberonazure")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<OberonContext>(null);
        }

        public DbSet<UsuarioDTO> Usuario { get; set; }
        public DbSet<ProductoDTO> Producto { get; set; }
        public DbSet<TallaDTO> Talla { get; set; }
        public DbSet<PedidoDTO> Pedidos { get; set; }
        public DbSet<ProductoPedidoDTO> ProductosPedido { get; set; }
    }
}
