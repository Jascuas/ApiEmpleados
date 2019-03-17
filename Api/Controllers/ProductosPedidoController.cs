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

namespace Api.Controllers
{
    [Authorize]
    public class ProductosPedidoController : ApiController
    {
        RepositoryOberon repo;

        public ProductosPedidoController()
        {
            this.repo = new RepositoryOberon();
        }
        
        public HttpResponseMessage Get(int id)
        {
            ClaimsIdentity identidad = User.Identity as ClaimsIdentity;
            if (identidad.FindFirst(ClaimTypes.Role).Value == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetProductosPedido(id));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        [Route("api/produductopedido/{id}")]
        public HttpResponseMessage GetProducto(int id)
        {
            ClaimsIdentity identidad = User.Identity as ClaimsIdentity;
            if (identidad.FindFirst(ClaimTypes.Role).Value == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetProductoPedido(id));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        public HttpResponseMessage Post(ProductoPedidoDTO pro)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            try
            {
                this.repo.RegistrarProductoPedido(pro);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        public void Put()
        {
        }

        
        public void Delete(int id)
        {
        }
    }
}
