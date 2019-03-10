using ApiOberon.Models;
using ApiOberon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public List<Pedido> Get()
        {
            return null;
        }
        [HttpGet]
        //[Route("api/Pedidos/{id}")]
        public List<Pedido> Get(int id_usuario)
        {
            return this.repo.GetPedidos(id_usuario);
        }
        [HttpGet]
        [Route("api/Pedido/{id}")]
        // GET: api/Productos/5
        public Pedido GetPedido(int id)
        {
            return this.repo.GetPedido(id);
        }
        // POST: api/Productos
        public void Post([FromBody]string value)
        {
        }
        // PUT: api/Productos/5
        public void Put(int id_Usuario, double total)
        {
            this.repo.RegistrarPedido(id_Usuario, total);
        }
       
        // DELETE: api/Productos/5
        public void Delete(int id)
        {
        }
    }
}
