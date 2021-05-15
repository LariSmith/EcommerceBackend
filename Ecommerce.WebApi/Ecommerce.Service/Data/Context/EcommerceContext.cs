using Ecommerce.Service.Data.Map;
using Ecommerce.Service.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Data.Context
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Produto> produtos { get; set; }

        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ecommerce;Data Source=DESKTOP-OG3NMRS\\BWDATOOLSET");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EcommerceMap());
        }
    }
}
