using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIAssignments.Interfaces;
using WebAPIAssignments.DataContext;
using WebAPIAssignments.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using WebAPIAssignments.Interfaces;

namespace WebAPIAssignments.Repository
{
    //[Table("Product")]
    public class ProductRepository<T> : IProductrRepository<T> where T : class
    {
        //public ProductRepository(MyDbContext DbContext)
        //{
        //    if (DbContext == null)
        //        throw new ArgumentNullException("Null DBcontext");

        //    MyDbContext = DbContext;
        //    DbSet = DbContext.Set<T>();
        //}
        //protected MyDbContext DbContext { get; set; }

        //protected DbSet<T> DbSet { get; set; }

        private MyDbContext ProductContext;
        public ProductRepository()
        {
            this.ProductContext = new MyDbContext();
            DbSet = ProductContext.Set<T>();
        }
        // private List<Product> _List = new List<Product>();
        protected DbSet<T> DbSet { get; set; }
        public IEnumerable<T> GetProduct()
        {
            //return db.Product;
            return DbSet;
        }
        public T FindById(int Id)
        {
            //var T = (from r in ProductContext.Products where r.Id == Id select r).FirstOrDefault();
            return DbSet.Find(Id);
        }
        public T AddDetails(T b)
        {
            //ProductContext.Products.Add(
            DbEntityEntry dbEntity = ProductContext.Entry(b);
            if (dbEntity.State != EntityState.Detached)
            {
                dbEntity.State = EntityState.Added;

            }
            else
            {
                DbSet.Add(b);

            }
            return b;
            //DbSet.Products.Add(b);
            //SaveChanges();

        }
        public void Update(T model)
        {
            //db.Entry(model).State = System.Data.Entity.EntityState.Modified;

            DbEntityEntry dbEntityEntry = ProductContext.Entry(model);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(model);
            }
            dbEntityEntry.State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = ProductContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }
        public void Delete(int id)
        {
            var findid = FindById(id);
            if (findid == null) return;
            Delete(findid);
            //ProductModel findid = db.Product.Find(id);
            //db.Product.Remove(findid);
            //db.SaveChanges();
        }



    }
}