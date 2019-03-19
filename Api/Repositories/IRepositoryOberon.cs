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
        UsuarioDTO ExisteUsuario(LoginCredentials credentials);
        UsuarioDTO LoginUsuario(LoginCredentials credentials);
        UsuarioDTO ExisteUsuario(int id_usuario);
        void RegistrarUsuario(RegisterCredentials credentials);
        List<UsuarioDTO> Usuarios();
        List<ProductoDTO> GetProductos();
        List<ProductoDTO> GetProductos(String tipo);
        ProductoDTO GetProducto(int id_producto);
        TallaDTO GetTalla(int id_talla);
        List<TallaDTO> GetTallasProducto(int id_producto);
        List<TallaDTO> GetTallas();
        PedidoDTO GetPedido(int id_pedido);
        List<PedidoDTO> GetPedidos();
        List<PedidoDTO> GetPedidos(int id_usurio);
        ProductoPedidoDTO GetProductoPedido(int id_producto);
        List<ProductoPedidoDTO> GetProductosPedido(int id_pedido);
        void RegistrarPedido(PedidoDTO pedido);
        void RegistrarProductoPedido(ProductoPedidoDTO pro);
    }
}
