using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entityes;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
