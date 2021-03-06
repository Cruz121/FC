
using FilmsCatalog.BL;
using FilmsCatalog.BL.Implementations;
using FilmsCatalog.BL.Interfaces;
using FilmsCatalog.DL;
using FilmsCatalog.DL.Entity;
using FilmsCatalog.PL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FilmsCatalog
{
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddMvc();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString, m => m.MigrationsAssembly("FilmsCatalog.DL")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DBContext>();

            services.AddScoped<IFilmsRepository, FilmsRepository>();
            services.AddScoped<DataManager>();
            services.AddScoped<ServicesManager>();

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Film}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
