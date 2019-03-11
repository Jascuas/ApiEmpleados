using ApiOberon.Entities;
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
        public IAsyncResult Post(PedidoDT pedido)
        {
            try
            {
                this.repo.RegistrarPedido(pedido);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(new { ex = ex.Message });
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
