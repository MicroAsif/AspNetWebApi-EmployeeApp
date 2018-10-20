using AspNetWebApi_EmployeeApp.AppDbContext;
using AspNetWebApi_EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace AspNetWebApi_EmployeeApp.Controllers
{
    public class ProductController : ApiController
    {
        // GET: Product
        private EmpDbContext Db;
        public ProductController()
        {
            Db = new EmpDbContext();
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Db.Products.ToList();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var pro = Db.Products.Find(id);
            if (pro != null)
                return Ok(pro);
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Post(Product model)
        {
            if (model != null)
            {
                Db.Products.Add(model);
                Db.SaveChanges();
                return Ok(model);
            }
            return Content(HttpStatusCode.BadRequest, "failed to save emp");
        }

        [HttpPut]
        public IHttpActionResult Put(Product model, int Id)
        {
            var pro = Db.Products.Find(Id);
            if (pro != null && ModelState.IsValid)
            {
                pro.Title = model.Title;
                pro.Price = model.Price;
                pro.ImageUrl= model.ImageUrl;
                pro.CategoryId = model.CategoryId;
                Db.SaveChanges();
                return Ok(model);
            }
            return Content(HttpStatusCode.BadRequest, "failed to update emp");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var pro = Db.Products.Find(id);
            if (pro != null)
            {
                Db.Products.Remove(pro);
                Db.SaveChanges();
                return Ok("sucessfully delete employee");
            }
            return Content(HttpStatusCode.BadRequest, "failed to delete");
        }
    }
}