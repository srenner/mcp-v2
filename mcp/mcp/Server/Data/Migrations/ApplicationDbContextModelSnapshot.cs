﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mcp.Server.Data;

namespace mcp.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Key");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("mcp.Server.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UniqueName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UniqueName")
                        .IsUnique()
                        .HasFilter("[UniqueName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("mcp.Server.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Engine",
                            SortOrder = 1
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Suspension/Chassis",
                            SortOrder = 2
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Brakes",
                            SortOrder = 3
                        },
                        new
                        {
                            CategoryID = 4,
                            Name = "Interior",
                            SortOrder = 4
                        },
                        new
                        {
                            CategoryID = 5,
                            Name = "Body",
                            SortOrder = 5
                        },
                        new
                        {
                            CategoryID = 6,
                            Name = "Electrical",
                            SortOrder = 6
                        },
                        new
                        {
                            CategoryID = 7,
                            Name = "Audio/Video",
                            SortOrder = 7
                        },
                        new
                        {
                            CategoryID = 8,
                            Name = "Drivetrain",
                            SortOrder = 8
                        });
                });

            modelBuilder.Entity("mcp.Server.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("ActualCost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCostPublic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TargetCost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime?>("TargetEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ProjectID");

                    b.HasIndex("UserCategoryID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("mcp.Server.Models.ProjectDependency", b =>
                {
                    b.Property<int>("ProjectDependencyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DependsOnProjectID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("ProjectDependencyID");

                    b.HasIndex("DependsOnProjectID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectDependency");
                });

            modelBuilder.Entity("mcp.Server.Models.ProjectPart", b =>
                {
                    b.Property<int>("ProjectPartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("QuantityPurchased")
                        .HasColumnType("int");

                    b.HasKey("ProjectPartID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectPart");
                });

            modelBuilder.Entity("mcp.Server.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("TagID");

                    b.ToTable("Tag");

                    b.HasData(
                        new
                        {
                            TagID = 1,
                            Description = "A vehicle being restored to a like-new state",
                            IsDeleted = false,
                            Name = "Restoration",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 2,
                            Description = "A vehicle being restored while making modifications along the way",
                            IsDeleted = false,
                            Name = "Restomod",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 3,
                            Description = "A vehicle that is built for performance but driven on public streets",
                            IsDeleted = false,
                            Name = "Performance Street",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 4,
                            Description = "A vehicle that is street driven and also goes to the drag strip",
                            IsDeleted = false,
                            Name = "Street/Strip",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 5,
                            Description = "A vehicle used on the drag strip that is rarely, if ever, street driven",
                            IsDeleted = false,
                            Name = "Drag",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 6,
                            Description = "A vehicle that competes in autocross competitions",
                            IsDeleted = false,
                            Name = "Autocross",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 7,
                            Description = "A vehicle that competes in road race competitions",
                            IsDeleted = false,
                            Name = "Road Race",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 8,
                            Description = "A vehicle built for road race events",
                            IsDeleted = false,
                            Name = "Drift",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 9,
                            Description = "A vehicle modified to deliberately look worn or unfinished",
                            IsDeleted = false,
                            Name = "Rat Rod",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 10,
                            Description = "A vehicle that is entered into car shows",
                            IsDeleted = false,
                            Name = "Show",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 11,
                            Description = "A vehicle with airbags or hydraulics modified in the lowrider style",
                            IsDeleted = false,
                            Name = "Lowrider",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 12,
                            Description = "A vehicle modified to be lower, often with stretched tires and lots of negative camber",
                            IsDeleted = false,
                            Name = "Stanced",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 13,
                            Description = "A vehicle from Europe, typically modified by removing seams, badges, or trim",
                            IsDeleted = false,
                            Name = "Euro",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 14,
                            Description = "A vehicle from Japan often modified in a Japanese style",
                            IsDeleted = false,
                            Name = "JDM",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 15,
                            Description = "A vehicle that has been lightly modified with upgraded parts from the manufacturer",
                            IsDeleted = false,
                            Name = "OEM+",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 16,
                            Description = "A vehicle modified to have an impressive stereo, often used in competition",
                            IsDeleted = false,
                            Name = "Stereo",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 17,
                            Description = "A vehicle from the 1930s and 1940s modified in the hot rod style",
                            IsDeleted = false,
                            Name = "Hot Rod",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 18,
                            Description = "A vehicle with collector value",
                            IsDeleted = false,
                            Name = "Collector",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 19,
                            Description = "A vehicle driven on a road course for fun instead of competition",
                            IsDeleted = false,
                            Name = "Open Track",
                            SortOrder = 0
                        },
                        new
                        {
                            TagID = 20,
                            Description = "A vehicle that is much faster than it looks",
                            IsDeleted = false,
                            Name = "Sleeper",
                            SortOrder = 0
                        });
                });

            modelBuilder.Entity("mcp.Server.Models.UserCategory", b =>
                {
                    b.Property<int>("UserCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserCategoryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("UserCategory");
                });

            modelBuilder.Entity("mcp.Server.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("EstimatedValue")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("ForSaleAskingPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ForSaleLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ForSaleTransactionPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForSale")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("TotalInvested")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VehicleID");

                    b.HasIndex("UserID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("mcp.Server.Models.VehicleModification", b =>
                {
                    b.Property<int>("VehicleModificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHighlighted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int?>("UserCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("VehicleModificationID");

                    b.HasIndex("UserCategoryID");

                    b.HasIndex("VehicleID");

                    b.ToTable("VehicleModification");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("mcp.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("mcp.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mcp.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("mcp.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mcp.Server.Models.Project", b =>
                {
                    b.HasOne("mcp.Server.Models.UserCategory", "UserCategory")
                        .WithMany()
                        .HasForeignKey("UserCategoryID");

                    b.HasOne("mcp.Server.Models.Vehicle", "Vehicle")
                        .WithMany("Projects")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCategory");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("mcp.Server.Models.ProjectDependency", b =>
                {
                    b.HasOne("mcp.Server.Models.Project", "DependsOnProject")
                        .WithMany()
                        .HasForeignKey("DependsOnProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mcp.Server.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DependsOnProject");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("mcp.Server.Models.ProjectPart", b =>
                {
                    b.HasOne("mcp.Server.Models.Project", "Project")
                        .WithMany("Parts")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("mcp.Server.Models.UserCategory", b =>
                {
                    b.HasOne("mcp.Server.Models.Category", "BaseCategory")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("mcp.Server.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("BaseCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("mcp.Server.Models.Vehicle", b =>
                {
                    b.HasOne("mcp.Server.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("mcp.Server.Models.VehicleModification", b =>
                {
                    b.HasOne("mcp.Server.Models.UserCategory", "UserCategory")
                        .WithMany()
                        .HasForeignKey("UserCategoryID");

                    b.HasOne("mcp.Server.Models.Vehicle", "Vehicle")
                        .WithMany("Modifications")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCategory");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("mcp.Server.Models.Project", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("mcp.Server.Models.Vehicle", b =>
                {
                    b.Navigation("Modifications");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
