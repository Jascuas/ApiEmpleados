using ApiOberon.Entities;
using ApiOberon.Models;
using ApiOberon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiOberon.Controllers
{
    public class PedidosController : ApiController
    {
        RepositoryOberon repo;

        public PedidosController()
        {
            this.repo = new RepositoryOberon();
        }
        //[Route("api/Pedidos/{id}")]

        // GET: api/Pedidos/5
        public Pedido Get(int id)
        {
            return this.repo.GetPedido(id);
        }
        [HttpGet]
        public List<Pedido> GetPedidos(int id_usuario)
        {
            return this.repo.GetPedidos(id_usuario);
        }
        // POST: api/Pedidos
        public HttpResponseMessage Post(Pedido pedido)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            try
            {
                Pedido p = this.repo.RegistrarPedido(pedido);
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
