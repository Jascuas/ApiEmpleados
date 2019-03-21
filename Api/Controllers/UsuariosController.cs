using ApiOberon.Entities;
using ApiOberon.Models;
using ApiOberon.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ApiOberon.Controllers
{
    [Authorize]
    public class UsuariosController : ApiController
    {
        RepositoryOberon repo;

        public UsuariosController()
        {
            this.repo = new RepositoryOberon();
        }
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.repo.ExisteUsuario(int.Parse(User.Identity.Name)));
        }
        [Route("api/Usuarios/{id_usuario}/Pedidos/")]
        public HttpResponseMessage GetPedidos(int id_usuario)
        {
            int user_id = int.Parse(User.Identity.Name);
            if (user_id == id_usuario)
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetPedidos(id_usuario));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        [Route("api/Usuarios/{id_usuario}/Pedidos/{id_pedido}")]
        public HttpResponseMessage GetPedido(int id_usuario, int id_pedido)
        {
            int user_id = int.Parse(User.Identity.Name);
            if (user_id == id_usuario)
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetPedido(id_pedido));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        [Route("api/Usuarios/{id_usuario}/Pedidos/{id_pedido}/ProductosPedido")]
        public HttpResponseMessage GetProductosPedido(int id_usuario, int id_pedido)
        {
            int user_id = int.Parse(User.Identity.Name);
            if (user_id == id_usuario)
            {
                List<ProductoPedidoDTO> productosPedido = this.repo.GetProductosPedido(id_pedido);
                List<ProductoPedido> productos = new List<ProductoPedido>();
                foreach (ProductoPedidoDTO p in productosPedido)
                { 
                    Producto pro = Mapper.Map<Producto>(this.repo.GetProductoFromTalla(p.id_Talla.Value));
                    ProductoPedido productopedido = new ProductoPedido(p.id_Producto_Pedido.Value, pro, p.id_Talla.Value, p.unidades.Value); 
                    productos.Add(productopedido);
                }
                return Request.CreateResponse(HttpStatusCode.OK, productos);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        [Route("api/Usuarios/{id_usuario}/Pedidos/{id_pedido}/ProductosPedido/{id_producto}")]
        public HttpResponseMessage GetProductoPedido(int id_usuario, int id_pedido, int id_producto)
        {
            int user_id = int.Parse(User.Identity.Name);
            if (user_id == id_usuario)
            {
                ProductoPedidoDTO p = this.repo.GetProductoPedido(id_producto);
                Producto pro = Mapper.Map<Producto>(this.repo.GetProductoFromTalla(p.id_Talla.Value));
                ProductoPedido productopedido = new ProductoPedido(p.id_Producto_Pedido.Value, pro, p.id_Talla.Value, p.unidades.Value);
                return Request.CreateResponse(HttpStatusCode.OK, productopedido);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        public void Delete(int id)
        {
          this.repo.EliminarUsuario(this.repo.ExisteUsuario(int.Parse(User.Identity.Name)));
        }
    }
}
