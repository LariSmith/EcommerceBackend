using Ecommerce.Service.Data.Context;
using Ecommerce.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Service.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected DbSet<T> dbSet;
        protected EcommerceContext context;

        public Repository(EcommerceContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public IQueryable<T> ObterQueryEntidade()
        {
            return dbSet.AsQueryable();
        }
    }
}
