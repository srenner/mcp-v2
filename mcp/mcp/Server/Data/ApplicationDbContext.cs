﻿using IdentityServer4.EntityFramework.Options;
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
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectDependency> ProjectDependency { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleModification> VehicleModification { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string dbType = "sql";

            if(dbType == "sql")
            {
                string currencyFormat = "decimal(10,2)";

                builder.Entity<ApplicationUser>().HasIndex(i => i.UniqueName).IsUnique(true);

                builder.Entity<Category>().HasData(new Category { CategoryID = 1, SortOrder = 1, Name = "Engine" });
                builder.Entity<Category>().HasData(new Category { CategoryID = 2, SortOrder = 2, Name = "Suspension/Chassis" });
                builder.Entity<Category>().HasData(new Category { CategoryID = 3, SortOrder = 3, Name = "Brakes" });
                builder.Entity<Category>().HasData(new Category { CategoryID = 4, SortOrder = 4, Name = "Interior" });
                builder.Entity<Category>().HasData(new Category { CategoryID = 5, SortOrder = 5, Name = "Body" });
                builder.Entity<Category>().HasData(new Category { CategoryID = 6, SortOrder = 6, Name = "Electrical" });
                builder.Entity<Category>().HasData(new Category { CategoryID = 7, SortOrder = 7, Name = "Audio/Video" });

                builder.Entity<Project>().Property(o => o.TargetCost).HasColumnType(currencyFormat);
                builder.Entity<Project>().Property(o => o.ActualCost).HasColumnType(currencyFormat);

                //TODO not sure if this is correct, but Projects will not normally be deleted, so this is ok for now
                builder.Entity<ProjectDependency>().HasOne(o => o.Project).WithMany().OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Vehicle>().Property(o => o.PurchasePrice).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.TotalInvested).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.EstimatedValue).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.ForSaleAskingPrice).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.ForSaleTransactionPrice).HasColumnType(currencyFormat);
            }
        }

    }
}
