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
        

        // DELETE: api/Productos/5
        public void Delete(int id)
        {
        }
    }
}
