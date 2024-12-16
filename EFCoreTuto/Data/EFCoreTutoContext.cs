using EFCoreTuto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTuto.Data
{
    public class EFCoreTutoContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlServer(@"Data Source=JARVISV\SQLEXPRESS;Initial Catalog=ef_core_tuto;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }
    }
}
