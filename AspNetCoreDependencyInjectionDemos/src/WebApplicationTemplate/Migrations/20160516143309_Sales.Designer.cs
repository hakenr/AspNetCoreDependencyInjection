using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WebApplicationTemplate.Models;

namespace WebApplicationTemplate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160516143309_Sales")]
    partial class Sales
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.BasicPrice", b =>
                {
                    b.Property<int>("BasicPriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductProductId");

                    b.HasKey("BasicPriceId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CustomerId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.CustomerPrice", b =>
                {
                    b.Property<int>("CustomerPriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerCustomerId");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductProductId");

                    b.HasKey("CustomerPriceId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.CustomerProductGroupDiscount", b =>
                {
                    b.Property<int>("CustomerProductGroupDiscountId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerCustomerId");

                    b.Property<decimal>("Discount");

                    b.Property<int?>("ProductGroupProductGroupId");

                    b.HasKey("CustomerProductGroupDiscountId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProductGroupProductGroupId");

                    b.Property<string>("ProductNumber");

                    b.HasKey("ProductId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.ProductGroup", b =>
                {
                    b.Property<int>("ProductGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ProductGroupId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplicationTemplate.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplicationTemplate.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("WebApplicationTemplate.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.BasicPrice", b =>
                {
                    b.HasOne("WebApplicationTemplate.Models.Sales.Product")
                        .WithMany()
                        .HasForeignKey("ProductProductId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.CustomerPrice", b =>
                {
                    b.HasOne("WebApplicationTemplate.Models.Sales.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCustomerId");

                    b.HasOne("WebApplicationTemplate.Models.Sales.Product")
                        .WithMany()
                        .HasForeignKey("ProductProductId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.CustomerProductGroupDiscount", b =>
                {
                    b.HasOne("WebApplicationTemplate.Models.Sales.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCustomerId");

                    b.HasOne("WebApplicationTemplate.Models.Sales.ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupProductGroupId");
                });

            modelBuilder.Entity("WebApplicationTemplate.Models.Sales.Product", b =>
                {
                    b.HasOne("WebApplicationTemplate.Models.Sales.ProductGroup")
                        .WithMany()
                        .HasForeignKey("ProductGroupProductGroupId");
                });
        }
    }
}
