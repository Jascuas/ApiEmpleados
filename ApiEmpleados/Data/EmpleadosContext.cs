using ApiEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiEmpleados.Data
{
    public class EmpleadosContext: DbContext
    {
        public EmpleadosContext() : base("name=cadenahospital")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EmpleadosContext>(null);
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}