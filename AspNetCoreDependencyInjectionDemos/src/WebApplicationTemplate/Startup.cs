using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplicationTemplate.Models;
using WebApplicationTemplate.Repositories.Sales;
using WebApplicationTemplate.Services;
using WebApplicationTemplate.Services.Sales;

namespace WebApplicationTemplate
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			// Add framework services.
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

			services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
	        services.AddTransient<IPriceResolver, PriceResolver>();

			// repositories
	        services.AddTransient<IBasicPriceRepository, BasicPriceRepository>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<ICustomerPriceRepository, CustomerPriceRepository>();
			services.AddTransient<ICustomerProductGroupDiscountRepository, CustomerProductGroupDiscountRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();

			// UI services
			services.AddTransient<ICustomerSelectOptions, CustomerSelectOptions>();
			services.AddTransient<IProductSelectOptions, ProductSelectOptions>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                        context.Database.Migrate();
                    }
                }
                catch { }
            }

			// Initial data seed
			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
				context.EnsureSeedData();
			}

            // app.UseIISIntegration();

            app.UseStaticFiles();

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

		// Entry point for the application.
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
