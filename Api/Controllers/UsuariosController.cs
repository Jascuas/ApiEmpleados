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
        [Route("api/Usuario")]
        public HttpResponseMessage GetUsuario()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.repo.ExisteUsuario(int.Parse(User.Identity.Name)));
        }
        public HttpResponseMessage Get(int id)
        {
            ClaimsIdentity identidad = User.Identity as ClaimsIdentity;
            if (identidad.FindFirst(ClaimTypes.Role).Value == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.ExisteUsuario(id));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
            
        }
        public HttpResponseMessage Get()
        {
            ClaimsIdentity identidad = User.Identity as ClaimsIdentity;
            if (identidad.FindFirst(ClaimTypes.Role).Value == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.Usuarios());
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
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
                List<ProductoPedido> productos = Mapper.Map<List<ProductoPedido>>(this.repo.GetProductosPedido(id_pedido));
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
                ProductoPedido producto = Mapper.Map<ProductoPedido>(this.repo.GetProductoPedido(id_producto));
                return Request.CreateResponse(HttpStatusCode.OK, producto);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        public void Delete(int id)
        {
          this.repo.EliminarUsuario(this.repo.ExisteUsuario(int.Parse(User.Identity.Name)));
        }
        [AllowAnonymous]
        public HttpResponseMessage Post(RegisterCredentials credentials)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            try
            {
                this.repo.RegistrarUsuario(credentials);
                return Request.CreateResponse(HttpStatusCode.OK, "Todo perfecto! Pruebe a loguearse.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPut]
        public HttpResponseMessage Put(Usuario user)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            try
            {
                UsuarioDTO u = this.repo.ExisteUsuario(int.Parse(User.Identity.Name));
                u.Nombre = user.Nombre;
                u.Apellidos = user.Apellidos;
                u.User = user.User;
                u.Email = user.Email;
                this.repo.ModificarUsuario(u);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
