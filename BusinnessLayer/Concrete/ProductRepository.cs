using BusinnessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Concrete
{
    public class ProductRepository:GenericRepository<Product> 
    {
        DataContext db = new DataContext();

        public List<Product> GetPopularProduct()
        {
            return db.Products.Where(x => x.Popular == true).Take(3).Take(3).Take(3).Take(3).ToList();
        }

    }
}
