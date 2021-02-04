using IdentityServer4.EntityFramework.Options;
using mcp.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string dbType = "sql";

            if(dbType == "sql")
            {
                string currencyFormat = "decimal(10,2)";

                builder.Entity<Vehicle>().Property(o => o.PurchasePrice).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.TotalInvested).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.EstimatedValue).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.ForSaleAskingPrice).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.ForSaleTransactionPrice).HasColumnType(currencyFormat);
            }
        }

    }
}
