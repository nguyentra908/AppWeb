using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebShop.Data.EF
{
    public class WebShopSolutionDbContext : IDesignTimeDbContextFactory<webshopDBContext>
    {
        public webshopDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
            var connectionString = configuration.GetConnectionString("WebShopDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<webshopDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new webshopDBContext(optionsBuilder.Options);
        }
    }
}