using IdentityServer4.EntityFramework.Options;
using mcp.Server.Models;
using mcp.Shared.Enum;
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
        public DbSet<ProjectChecklistItem> ProjectChecklistItem { get; set; }
        public DbSet<ProjectDependency> ProjectDependency { get; set; }
        public DbSet<ProjectPart> ProjectPart { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<ProjectTool> ProjectTool { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleModification> VehicleModification { get; set; }
        public DbSet<Tag> Tag { get; set; }


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
                builder.Entity<Category>().HasData(new Category { CategoryID = 8, SortOrder = 8, Name = "Drivetrain" });

                builder.Entity<Project>().Property(o => o.TargetCost).HasColumnType(currencyFormat);
                builder.Entity<Project>().Property(o => o.ActualCost).HasColumnType(currencyFormat);
                builder.Entity<Project>().Property(p => p.ProjectStatusID).HasDefaultValue(1);

                builder.Entity<ProjectDependency>().HasOne(o => o.DependsOnProject).WithMany(m => m.DependenciesOf).HasForeignKey(k => k.DependsOnProjectID).OnDelete(DeleteBehavior.Restrict);
                builder.Entity<ProjectDependency>().HasOne(o => o.Project).WithMany(m => m.Dependencies).HasForeignKey(k => k.ProjectID).OnDelete(DeleteBehavior.Restrict);

                builder.Entity<ProjectPart>().Property(o => o.Price).HasColumnType(currencyFormat);
                builder.Entity<ProjectPart>().Property(o => o.ExtraCost).HasColumnType(currencyFormat);
                builder.Entity<ProjectPart>().Property(o => o.Quantity).HasDefaultValue(1);

                foreach (ProjectStatusEnum status in Enum.GetValues(typeof(ProjectStatusEnum)))
                {
                    builder.Entity<ProjectStatus>().HasData(new ProjectStatus { ProjectStatusID = (int)status, Name = status.ToString() });
                }

                builder.Entity<ProjectTool>().Property(p => p.Price).HasColumnType(currencyFormat);
                builder.Entity<ProjectTool>().Property(p => p.AppliedPrice).HasColumnType(currencyFormat);
                builder.Entity<ProjectTool>().Property(p => p.Quantity).HasDefaultValue(1);

                builder.Entity<Tag>().HasData(new Tag { TagID = 1, Name = "Restoration", Description = "A vehicle being restored to a like-new state" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 2, Name = "Restomod", Description = "A vehicle being restored while making modifications along the way" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 3, Name = "Performance Street", Description = "A vehicle that is built for performance but driven on public streets" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 4, Name = "Street/Strip", Description = "A vehicle that is street driven and also goes to the drag strip" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 5, Name = "Drag", Description = "A vehicle used on the drag strip that is rarely, if ever, street driven" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 6, Name = "Autocross", Description = "A vehicle that competes in autocross competitions" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 7, Name = "Road Race", Description = "A vehicle that competes in road race competitions" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 8, Name = "Drift", Description = "A vehicle built for drift events" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 9, Name = "Rat Rod", Description = "A vehicle modified to deliberately look worn or unfinished" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 10, Name = "Show", Description = "A vehicle that is entered into car shows" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 11, Name = "Lowrider", Description = "A vehicle with airbags or hydraulics modified in the lowrider style" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 12, Name = "Stanced", Description = "A vehicle modified to be lower, often with stretched tires and lots of negative camber" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 13, Name = "Euro", Description = "A vehicle from Europe, typically modified by removing seams, badges, or trim" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 14, Name = "JDM", Description = "A vehicle from Japan often modified in a Japanese style" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 15, Name = "OEM+", Description = "A vehicle that has been lightly modified with upgraded parts from the manufacturer" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 16, Name = "Stereo", Description = "A vehicle modified to have an impressive stereo, often used in competition" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 17, Name = "Hot Rod", Description = "A vehicle from the 1930s and 1940s modified in the hot rod style" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 18, Name = "Collector", Description = "A vehicle with collector value" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 19, Name = "Open Track", Description = "A vehicle driven on a road course for fun instead of competition" });
                builder.Entity<Tag>().HasData(new Tag { TagID = 20, Name = "Sleeper", Description = "A vehicle that is much faster than it looks" });

                builder.Entity<Vehicle>().Property(o => o.PurchasePrice).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.TotalInvested).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.EstimatedValue).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.ForSaleAskingPrice).HasColumnType(currencyFormat);
                builder.Entity<Vehicle>().Property(o => o.ForSaleTransactionPrice).HasColumnType(currencyFormat);

            }
        }

    }
}
