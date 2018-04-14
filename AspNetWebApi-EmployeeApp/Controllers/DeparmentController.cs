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
    public class DeparmentController : ApiController
    {
        private EmpDbContext Db; 
        public DeparmentController()
        {
            Db = new EmpDbContext();
        }
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return Db.Depertment.ToList();
        }
        [HttpPost]
        public IHttpActionResult Post(Department model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid");
            Db.Depertment.Add(model);
            Db.SaveChanges();
            return Ok(model);
        }
        [HttpPut]
        public IHttpActionResult Put(Department model)
        {
            var dept = Db.Depertment.Find(model.Id); 
            if (dept != null && ModelState.IsValid)
            {
                dept.Name = model.Name;
                Db.SaveChanges();
                return Ok(dept);
            }
            return BadRequest("Failed");
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var dept = Db.Depertment.Find(id);
            if (dept != null)
            {
                Db.Depertment.Remove(dept);
                Db.SaveChanges();
                return Ok("Successfully deleted");
            }
            return NotFound();
        }
    }
}
