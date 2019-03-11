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

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Talla> Talla { get; set; }
        public DbSet<PedidoDT> Pedidos { get; set; }
        public DbSet<ProductoPedido> ProductosPedido { get; set; }
    }
}
