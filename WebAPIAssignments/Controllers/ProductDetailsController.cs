using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIAssignments.DataContext;
using WebAPIAssignments.Models;
using WebAPIAssignments.Repository;
using WebAPIAssignments.Interfaces;

namespace WebAPIAssignments.Controllers
{
    public class ProductDetailsController : ApiController
    {
        //static readonly IProductrRepository databasePlaceholder = new ProductRepository() as IProductrRepository;
        ProductRepository<Product> databasePlaceholder = new ProductRepository<Product>();

        private int _nextId = 1;
        public IEnumerable<Product> GetAllProduct()
        {
            return databasePlaceholder.GetProduct();
            //return databasePlaceholder.
        }
        [HttpGet]
        public Product FindById(int Id)
        {
            //var c = (from r in db.Product where r.Id == Id select r).FirstOrDefault();
            return databasePlaceholder.FindById(Id);
        }
        //ProductRepository databasePlaceholder = new ProductRepository();
        //ProductRepository DbProduct = new ProductRepository();
        [HttpPost]
        public Product Add(Product b)
        {
            b.Id = _nextId++;
           var res= databasePlaceholder.AddDetails(b);
            
           return res;
            // db.Product.Add(b);
            //db.SaveChanges();

        }

        [HttpPut]
        public void Update(Product model)
        {
            databasePlaceholder.Update(model);
            //db.Entry(model).State = System.Data.Entity.EntityState.Modified;

        }
        [HttpDelete]
        public void Delete(Product entity)
        {

            //return Ok("Resource Deleted"); 
            databasePlaceholder.Delete(entity);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            databasePlaceholder.Delete(id);
        }

    }
}
