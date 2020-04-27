namespace AsphaltDelivery.Web
{
    using System.Reflection;

    using AsphaltDelivery.Data;
    using AsphaltDelivery.Data.Common;
    using AsphaltDelivery.Data.Common.Repositories;
    using AsphaltDelivery.Data.Models;
    using AsphaltDelivery.Data.Repositories;
    using AsphaltDelivery.Data.Seeding;
    using AsphaltDelivery.Services;
    using AsphaltDelivery.Services.Data;
    using AsphaltDelivery.Services.Data.AsphaltBases;
    using AsphaltDelivery.Services.Data.AsphaltMixtures;
    using AsphaltDelivery.Services.Data.Courses;
    using AsphaltDelivery.Services.Data.Drivers;
    using AsphaltDelivery.Services.Data.Firms;
    using AsphaltDelivery.Services.Data.Models.Drivers;
    using AsphaltDelivery.Services.Data.Pictures;
    using AsphaltDelivery.Services.Data.RoadObjects;
    using AsphaltDelivery.Services.Data.Trucks;
    using AsphaltDelivery.Services.Mapping;
    using AsphaltDelivery.Services.Messaging;
    using AsphaltDelivery.Web.Hubs;
    using AsphaltDelivery.Web.ViewModels;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSignalR();

            Account account = new Account(
                this.configuration["Cloudinary:cloudName"],
                this.configuration["Cloudinary:APIKey"],
                this.configuration["Cloudinary:APISecret"]);

            Cloudinary cloudinary = new Cloudinary(account);

            services.AddSingleton(cloudinary);

            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = this.configuration["FacebookSettings:AppId"];
                    facebookOptions.AppSecret = this.configuration["FacebookSettings:AppSecret"];
                });

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(configure =>
            configure.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(this.configuration["SendGrid:APIKey"]));
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();

            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<ITruckService, TruckService>();
            services.AddTransient<IFirmService, FirmService>();
            services.AddTransient<IAsphaltBaseService, AsphaltBaseService>();
            services.AddTransient<IAsphaltMixtureService, AsphaltMixtureService>();
            services.AddTransient<IRoadObjectService, RoadObjectService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IPictureService, PictureService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, typeof(AllDriversServiceModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                // app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapHub<ChatHub>("/chat");
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
