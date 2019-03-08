using ApiEmpleados.Models;
using ApiEmpleados.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiEmpleados.Controllers
{
    public class EmpleadosController : ApiController
    {
        RepositoryEmpleados repo;

        public EmpleadosController()
        {
            this.repo = new RepositoryEmpleados();
        }

        public List<Empleado> GetEmpleados()
        {
            return this.repo.GetEmpleados(); 
        }
        public Empleado GetEmpleado(int id)
        {
            return this.repo.GetEmpleado(id);
        }
        [HttpGet]
        [Route("api/EmpleadosSalario/{salario}")]

        public List<Empleado> GetEmpleadosSalario(int salario)
        {
            return this.repo.GetEmpleadosSalario(salario);
        }
        [HttpGet]
        [Route("api/EmpleadosOficio/{oficio}")]

        public List<Empleado> GetEmpleadosOficio(String oficio)
        {
            return this.repo.GetEmpleadosOficio(oficio);
        }
    }
}
