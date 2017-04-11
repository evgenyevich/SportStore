﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entityes;

namespace SportsStore.Domain.Concrete
{
    class EFDbContext:DbContext
    {
        public EFDbContext():base("SportStore")
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
