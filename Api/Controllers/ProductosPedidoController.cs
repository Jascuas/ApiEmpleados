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
        public ProductoPedido Get(int id)
        {
            return this.repo.GetProductoPedido(id);
        }
        [HttpGet]
        public List<ProductoPedido> GetProductosPedido(int id_pedido)
        {
            return this.repo.GetProductosPedido(id_pedido);
        }
        
        // POST: api/ProductosPedido
        public void Post(ProductoPedido pro)
        {
            this.repo.RegistrarProductoPedido(pro);
        }
        public void Put()
        {
        }

        // DELETE: api/ProductosPedido/5
        public void Delete(int id)
        {
        }
    }
}
