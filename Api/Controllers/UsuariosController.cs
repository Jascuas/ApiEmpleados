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
        public List<Usuario> Get()
        {
            return this.repo.Usuarios();
        }
        public Usuario Get(int id)
        {
            return this.repo.ExisteUsuario(id);
        }
        // GET: api/Productos
        //[Route("")]
        [HttpPost]
        public Usuario Post([FromBody] String email, String password)
        {
            return this.repo.ExisteUsuario(email, password);
        }
        // POST: api/Productos
        public void Post(String password, String nombre, String apellidos, String email)
        {
            this.repo.RegistrarUsuario(password, nombre, apellidos, email);
        }
        // PUT: api/Productos/5
        public void Put()
        {
        }

        // DELETE: api/Productos/5
        public void Delete(int id)
        {
        }
    }
}
