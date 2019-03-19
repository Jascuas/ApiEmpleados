using ApiOberon.Entities;
using ApiOberon.Models;
using ApiOberon.Repositories;
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
    public class PedidosController : ApiController
    {
        RepositoryOberon repo;
        public PedidosController()
        {
            this.repo = new RepositoryOberon();
        }
        public HttpResponseMessage Get()
        {
            ClaimsIdentity identidad = User.Identity as ClaimsIdentity;
            if (identidad.FindFirst(ClaimTypes.Role).Value == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetPedidos());
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        public HttpResponseMessage Get(int id)
        {
            ClaimsIdentity identidad = User.Identity as ClaimsIdentity;
            if (identidad.FindFirst(ClaimTypes.Role).Value == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetPedido(id));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        // POST: api/Pedidos
        public HttpResponseMessage Post(PedidoDTO pedido)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            try
            {
                PedidoDTO p = this.repo.RegistrarPedido(pedido);
                return Request.CreateResponse(HttpStatusCode.OK, p);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Pedidos/5
        public void Put()
        {
        }

        // DELETE: api/Pedidos/5
        public void Delete(int id)
        {
        }
    }
}
