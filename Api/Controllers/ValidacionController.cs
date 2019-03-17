using ApiOberon.Entities;
using ApiOberon.Models;
using ApiOberon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiOberon.Controllers
{
    public class ValidacionController : ApiController
    {
        RepositoryOberon repo;

        public ValidacionController()
        {
            this.repo = new RepositoryOberon();
        }
        [HttpPost]
        [Route("api/validacion/Login")]
        public HttpResponseMessage Post(LoginCredentials credentials)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            try
            {
                UsuarioDTO u = this.repo.ExisteUsuario(credentials);
                if (u == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "El usuario o el email no existen en nuestra plataforma");
                }
                 u = this.repo.LoginUsuario(credentials);
                if (u == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "La contraseña no coincide para este usuario");
                }else
                return Request.CreateResponse(HttpStatusCode.OK, new {usuario = u});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/validacion/Register")]
        public HttpResponseMessage Post(RegisterCredentials credentials)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            try
            {
                this.repo.RegistrarUsuario(credentials);
                return Request.CreateResponse(HttpStatusCode.OK, "Todo perfecto! Pruebe a loguearse.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
    }
}
