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
    public class TallasController : ApiController
    {
        RepositoryOberon repo;

        public TallasController()
        {
            this.repo = new RepositoryOberon();
        }
        // GET: api/Productos

        public List<TallaDTO> Get()
        {
            return this.repo.GetTallas();
        }
        //[HttpGet]
        //[Route("api/Productos/{id}")]
        // GET: api/Productos/5
        public TallaDTO Get(int id)
        {
            return this.repo.GetTalla(id);
        }
        [HttpGet]
        public List<TallaDTO> GetTallas(int id_producto)
        {
            return this.repo.GetTallasProducto(id_producto);
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
