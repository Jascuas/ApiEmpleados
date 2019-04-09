using ApiOberon.Data;
using ApiOberon.Entities;
using ApiOberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ApiOberon.Repositories
{
    public class RepositoryOberon : IRepositoryOberon
    {
        OberonContext context;

        public RepositoryOberon()
        {
            this.context = new OberonContext();
        }
        
        public List<UsuarioDTO> Usuarios()
        {
            var consulta = from datos in context.Usuario select datos;
            return consulta.ToList();
        }
        public UsuarioDTO ExisteUsuario(LoginCredentials credentials)
        {
            var consulta = from datos in context.Usuario where (datos.Email == credentials.Identifier || datos.User == credentials.Identifier) select datos;
            return consulta.FirstOrDefault();
        }
        public UsuarioDTO LoginUsuario(LoginCredentials credentials)
        {
            var consulta = from datos in context.Usuario where (datos.Email == credentials.Identifier || datos.User == credentials.Identifier) && datos.Password == credentials.Password select datos;
            return consulta.FirstOrDefault();
        }
        public UsuarioDTO ExisteUsuario(int id_usuario)
        {
            var consulta = from datos in context.Usuario where datos.Id_Usuario == id_usuario select datos;
            return consulta.FirstOrDefault();
        }
        public void RegistrarUsuario(RegisterCredentials credentials)
        {
            String user = credentials.Nombre + " " + credentials.Apellidos;
            DateTime fecha = DateTime.Now;
            String rol = "cliente";
            UsuarioDTO u = new UsuarioDTO(credentials.Password, user, credentials.Nombre, credentials.Apellidos, credentials.Email, rol, fecha);
            this.context.Usuario.Add(u);
            this.context.SaveChanges();
        }
        public void ModificarUsuario(UsuarioDTO user)
        {
            UsuarioDTO usuario = this.context.Usuario.Find(user.Id_Usuario);
            usuario = user;
            this.context.SaveChanges();
        }

        public ProductoDTO GetProducto(int id_producto)
        {
            ProductoDTO producto = context.Producto.Where(x => x.Id_Producto == id_producto).Include(x => x.Tallas).FirstOrDefault();
            return producto;
        }
        public List<ProductoDTO> GetProductos()
        {
            List<ProductoDTO> producto = context.Producto.Include(x => x.Tallas).ToList();
            return producto;
        }
        public List<ProductoDTO> GetProductos(String tipo)
        {
            List<ProductoDTO> producto = context.Producto.Where(x => x.Tipo == tipo).Include(x => x.Tallas).ToList();
            return producto;
        }
        public ProductoDTO GetProductoFromTalla(int id_talla)
        {
            var consulta = from datos in context.Producto where datos.Id_Producto == (from data in context.Talla where data.Id_Talla == id_talla select data.Id_Producto).FirstOrDefault() select datos;
            return consulta.FirstOrDefault();
        }
        public TallaDTO GetTalla(int id_talla)
        {
            var consulta = from datos in context.Talla where datos.Id_Talla == id_talla select datos;
            return consulta.FirstOrDefault();
        }

        public List<TallaDTO> GetTallasProducto(int id_producto)
        {
            var consulta = from datos in context.Talla where datos.Id_Producto == id_producto select datos;
            return consulta.ToList();
        }

        public List<TallaDTO> GetTallas()
        {
            var consulta = from datos in context.Talla select datos;
            return consulta.ToList();
        }
        public PedidoDTO GetPedido(int id_pedido)
        {
            var consulta = from datos in context.Pedidos where datos.id_pedido == id_pedido select datos;
            return consulta.FirstOrDefault();
        }
        public List<PedidoDTO> GetPedidos()
        {
            var consulta = from datos in context.Pedidos select datos;
            return consulta.ToList();
        }

        public List<PedidoDTO> GetPedidos(int id_usurio)
        {
            var consulta = from datos in context.Pedidos where datos.id_Usuario == id_usurio select datos;
            return consulta.ToList();
        }
        public ProductoPedidoDTO GetProductoPedido(int id_producto)
        {
            ProductoPedidoDTO producto = context.ProductosPedido.Where(x => x.Id_Producto_Pedido == id_producto).Include(x =>x.Producto).FirstOrDefault();
            return producto;
        }
        public List<ProductoPedidoDTO> GetProductosPedido(int id_pedido)
        {
            List<ProductoPedidoDTO> producto = context.ProductosPedido.Where(x => x.Id_Pedido == id_pedido).Include(x => x.Producto).ToList();
            return producto;
        }
        public List<ProductoPedidoDTO> GetProductosPedidos()
        {
            List<ProductoPedidoDTO> producto = context.ProductosPedido.Include(x => x.Producto).ToList();
            return producto;
        }

        public PedidoDTO RegistrarPedido(PedidoDTO pedido)
        {
            DateTime fecha = DateTime.Now;
            pedido.fecha_Pedido = fecha;
            this.context.Pedidos.Add(pedido);
            this.context.SaveChanges();
            return pedido;
        }

        public void RegistrarProductoPedido(ProductoPedidoDTO pro)
        {
            this.context.ProductosPedido.Add(pro);
            this.context.SaveChanges();
        }
        public void EliminarUsuario(UsuarioDTO u)
        {
            this.context.Usuario.Remove(u);
            this.context.SaveChanges();
        }
    }
}
