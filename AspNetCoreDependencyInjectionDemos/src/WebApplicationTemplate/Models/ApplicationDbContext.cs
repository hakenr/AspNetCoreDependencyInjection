﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
	    public DbSet<BasicPrice> BasicPrices { get; set; }

	    public DbSet<Customer> Customers { get; set; }

	    public DbSet<CustomerPrice> CustomerPrices { get; set; }

	    public DbSet<CustomerProductGroupDiscount> CustomerProductGroupDiscounts { get; set; }

	    public DbSet<Product> Products { get; set; }

	    public DbSet<ProductGroup> ProductGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

	        builder.Entity<BasicPrice>().HasKey(e => e.BasicPriceId);
			builder.Entity<Customer>().HasKey(e => e.CustomerId);
			builder.Entity<CustomerPrice>().HasKey(e => e.CustomerPriceId);
			builder.Entity<CustomerProductGroupDiscount>().HasKey(e => e.CustomerProductGroupDiscountId);
			builder.Entity<Product>().HasKey(e => e.ProductId);
			builder.Entity<ProductGroup>().HasKey(e => e.ProductGroupId);
		}
	}
}
