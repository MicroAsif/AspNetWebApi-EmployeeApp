using AspNetWebApi_EmployeeApp.AppDbContext;
using AspNetWebApi_EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApi_EmployeeApp.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmpDbContext Db;
        public EmployeeController()
        {
            Db = new EmpDbContext();
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return Db.Employee.ToList();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var emp = Db.Employee.Find(id);
            if (emp != null)
                return Ok(emp);
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Post(Employee model)
        {
            if (ModelState.IsValid)
            {
                Db.Employee.Add(model);
                Db.SaveChanges();
                return Ok(model);
            }
            return Content(HttpStatusCode.BadRequest, "failed to save emp");
        }

        [HttpPut]
        public IHttpActionResult Put(Employee model)
        {
            var emp = Db.Employee.Find(model.Id);
            if (emp != null && ModelState.IsValid)
            {
                emp.Name = model.Name;
                emp.Email = model.Email;
                emp.Designation = model.Designation;
                emp.Sallary = model.Sallary;
                emp.DepertmentId = model.DepertmentId;
                Db.SaveChanges();
                return Ok(model);
            }
            return Content(HttpStatusCode.BadRequest, "failed to update emp");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var emp = Db.Employee.Find(id); 
            if (emp != null)
            {
                Db.Employee.Remove(emp);
                Db.SaveChanges();
                return Ok("sucessfully delete employee");
            }
            return Content(HttpStatusCode.BadRequest, "failed to delete");
        }
    }
}
