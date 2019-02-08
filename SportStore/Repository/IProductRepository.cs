using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Repository
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
