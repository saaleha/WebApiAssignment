using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIAssignments.Models;


namespace WebAPIAssignments.Interfaces
{
    interface IProductrRepository<T> where T : class
    {
        //IEnumerable<ProductModel> GetAll();
        //ProductModel Get();
        //ProductModel Add();
        //void Remove();
        //bool Update();


        T AddDetails(T b);
        void Update(T b);
        IEnumerable<T> GetProduct();
        T FindById(int Id);
        void Delete(T entity);
        void Delete(int id);
    }
}
