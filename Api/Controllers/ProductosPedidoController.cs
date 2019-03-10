using ApiOberon.Models;
using ApiOberon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ProductosPedidoController : ApiController
    {
        RepositoryOberon repo;

        public ProductosPedidoController()
        {
            this.repo = new RepositoryOberon();
        }
        [HttpGet]
        public List<ProductoPedido> Get(int id_pedido)
        {
            return this.repo.GetProductosPedido(id_pedido);
        }
        [HttpGet]
        [Route("api/ProductoPedido/{id}")]
        public ProductoPedido GetProductoPedido(int id_pro)
        {
            return this.repo.GetProductoPedido(id_pro);
        }
        // POST: api/ProductosPedido
        public void Post([FromBody]string value)
        {
        }
        public void Put(ProductoPedido pro)
        {
            this.repo.RegistrarProductoPedido(pro);
        }

        // DELETE: api/ProductosPedido/5
        public void Delete(int id)
        {
        }
    }
}
