using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shoppe.Data.EF
{
    public class ShoppeDbContextFactory : IDesignTimeDbContextFactory<ShoppeDbContext>
    {
        public ShoppeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ShoppeSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<ShoppeDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShoppeDbContext(optionsBuilder.Options);
        }
    }
}
