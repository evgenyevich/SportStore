using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entityes;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        //private IQueryable<Product> _products;
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products => context.Products;
    }
}
