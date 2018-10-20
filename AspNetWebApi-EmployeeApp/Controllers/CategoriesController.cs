using AspNetWebApi_EmployeeApp.AppDbContext;
using AspNetWebApi_EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AspNetWebApi_EmployeeApp.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: Categories
        private EmpDbContext Db;
        public CategoriesController()
        {
            Db = new EmpDbContext();
        }
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return Db.categories.ToList();
        }
        [HttpPost]
        public IHttpActionResult Post(Category model)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid");
            Db.categories.Add(model);
            Db.SaveChanges();
            return Ok(model);
        }
        [HttpPut]
        public IHttpActionResult Put(Category model)
        {
            var cate = Db.categories.Find(model.Id);
            if (cate != null && ModelState.IsValid)
            {
                cate.Name = model.Name;
                Db.SaveChanges();
                return Ok(cate);
            }
            return BadRequest("Failed");
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var cate = Db.categories.Find(id);
            if (cate != null)
            {
                Db.categories.Remove(cate);
                Db.SaveChanges();
                return Ok("Successfully deleted");
            }
            return NotFound();
        }
    }
}