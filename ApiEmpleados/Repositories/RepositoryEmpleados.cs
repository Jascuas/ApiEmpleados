using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiEmpleados.Data;
using ApiEmpleados.Models;

namespace ApiEmpleados.Repositories
{
    public class RepositoryEmpleados : IRepositoryEmpleados
    {
        EmpleadosContext context;

        public RepositoryEmpleados()
        {
            this.context = new EmpleadosContext();
        }
        public Empleado GetEmpleado(int emp_no)
        {
            var consulta = from datos in context.Empleados where datos.IdEmpleado == emp_no select datos;
            return consulta.FirstOrDefault();
        }

        public List<Empleado> GetEmpleados()
        {
            return this.context.Empleados.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in context.Empleados where datos.Oficio == oficio select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosSalario(int salario)
        {
            var consulta = from datos in context.Empleados where datos.Salario >= salario select datos;
            return consulta.ToList();
        }
    }
}