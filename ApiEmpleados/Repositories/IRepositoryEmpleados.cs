using ApiEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEmpleados.Repositories
{
    public interface IRepositoryEmpleados
    {
        Empleado GetEmpleado(int emp_no);
        List<Empleado> GetEmpleados();
        List<Empleado> GetEmpleadosOficio(String oficio);
        List<Empleado> GetEmpleadosSalario(int salario);

    }
}