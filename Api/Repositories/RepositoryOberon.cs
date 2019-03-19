using ApiOberon.Data;
using ApiOberon.Entities;
using ApiOberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public List<ProductoDTO> GetProductos()
        {
            var consulta = from datos in context.Producto select datos;
            return consulta.ToList();
        }
        public List<ProductoDTO> GetProductos(String tipo)
        {
            var consulta = from datos in context.Producto where datos.Tipo == tipo select datos;
            return consulta.ToList();
        }
        public ProductoDTO GetProducto(int id_producto)
        {
            var consulta = from datos in context.Producto where datos.Id_Producto == id_producto select datos;
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
            var consulta = from datos in context.ProductosPedido where datos.id_Producto_Pedido == id_producto select datos;
            return consulta.FirstOrDefault();
        }

        public List<ProductoPedidoDTO> GetProductosPedido(int id_pedido)
        {
            var consulta = from datos in context.ProductosPedido where datos.id_Pedido == id_pedido select datos;
            return consulta.ToList();
        }

        public void RegistrarPedido(PedidoDTO pedido)
        {
            DateTime fecha = DateTime.Now;
            pedido.fecha_Pedido = fecha;
            this.context.Pedidos.Add(pedido);
            this.context.SaveChanges();
        }

        public void RegistrarProductoPedido(ProductoPedidoDTO pro)
        {
            this.context.ProductosPedido.Add(pro);
            this.context.SaveChanges();
        }
    }
}
