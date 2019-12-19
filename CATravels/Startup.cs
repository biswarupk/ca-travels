namespace CATravels
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using CatTravels.Service.Abstract;
    using CatTravels.Repository.Abstract;
    using CatTravels.Utility.Abstract;
    using CatTravels.Service.Concrete;
    using CatTravels.Repository.Concrete;
    using CatTravels.Utility.Concrete;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var apiUrl = this.Configuration.GetSection("APIUrl").Value;
            var authCode = this.Configuration.GetSection("AuthCode").Value;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelRepository, HotelRepository>(serviceProvider =>
            {
                return new HotelRepository(apiUrl, authCode);
            });
            services.AddScoped<ILogger, Logger>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Hotel}/{action=Index}/{id?}");
            });
        }
    }
}
