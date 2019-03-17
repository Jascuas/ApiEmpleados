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
    public class ProductosController : ApiController
    {
        RepositoryOberon repo;

        public ProductosController()
        {
            this.repo = new RepositoryOberon();
        }
        // GET: api/Productos
        
        public List<ProductoDTO> Get()
        {
            return this.repo.GetProductos();
        }
        //[HttpGet]
        //[Route("api/Productos/{id}")]
        // GET: api/Productos/5
        public ProductoDTO Get(int id)
        {
            return this.repo.GetProducto(id);
        }
        [HttpGet]
        public List<ProductoDTO> Get(string tipo)
        {
            return this.repo.GetProductos(tipo);
        }
        // POST: api/Productos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Productos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Productos/5
        public void Delete(int id)
        {
        }
    }
}
