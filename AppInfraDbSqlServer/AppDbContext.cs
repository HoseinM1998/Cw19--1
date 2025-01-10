using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppInfraDbSqlServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public AppDbContext(DbContextOptions options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=DESKTOP-78B19T2\SQLEXPRESS; Initial Catalog=Cw20; User Id=sa; Password=13771377; TrustServerCertificate=True;");
        }
    }
}
