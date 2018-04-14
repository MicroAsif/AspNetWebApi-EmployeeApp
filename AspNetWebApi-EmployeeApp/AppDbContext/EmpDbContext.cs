using AspNetWebApi_EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetWebApi_EmployeeApp.AppDbContext
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext() : base("EmpContext")
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Depertment { get; set; }

    }
}