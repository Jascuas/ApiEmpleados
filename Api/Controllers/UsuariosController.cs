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
    public class UsuariosController : ApiController
    {
        RepositoryOberon repo;

        public UsuariosController()
        {
            this.repo = new RepositoryOberon();
        }
        // GET: api/Productos
        public Usuario Get(String email, String password)
        {
            return this.repo.ExisteUsuario(email, password);
        }
        [HttpGet]
        //[Route("api/Productos/{id}")]
        // GET: api/Productos/5
        public Usuario Get(int id)
        {
            return this.repo.ExisteUsuario(id);
        }
        
        // POST: api/Productos
        public void Post([FromBody]string value)
        {
        }
        [HttpPut]
        // PUT: api/Productos/5
        public void Put(String password, String nombre, String apellidos, String email)
        {
            this.repo.RegistrarUsuario(password, nombre, apellidos, email);
        }

        // DELETE: api/Productos/5
        public void Delete(int id)
        {
        }
    }
}
