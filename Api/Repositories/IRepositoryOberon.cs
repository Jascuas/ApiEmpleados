using ApiOberon.Entities;
using ApiOberon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Repositories
{
    public interface IRepositoryOberon
    {
        Usuario ExisteUsuario(LoginCredentials credentials);
        Usuario LoginUsuario(LoginCredentials credentials);
        Usuario ExisteUsuario(int id_usuario);
        void RegistrarUsuario(RegisterCredentials credentials);
        List<Usuario> Usuarios();
        List<Producto> GetProductos();
        List<Producto> GetProductos(String tipo);
        Producto GetProducto(int id_producto);
        Talla GetTalla(int id_talla);
        List<Talla> GetTallasProducto(int id_producto);
        List<Talla> GetTallas();
        Pedido GetPedido(int id_pedido);
        List<Pedido> GetPedidos(int id_usurio);
        ProductoPedido GetProductoPedido(int id_producto);
        List<ProductoPedido> GetProductosPedido(int id_pedido);
        Pedido RegistrarPedido(Pedido pedido);
        void RegistrarProductoPedido(ProductoPedido pro);
    }
}
