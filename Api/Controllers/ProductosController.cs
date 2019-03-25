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
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetProductos());
        }
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetProducto(id));
        }
        
        [HttpGet]
        public HttpResponseMessage Get(string tipo)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.repo.GetProductos(tipo));
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
