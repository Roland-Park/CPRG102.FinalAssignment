using CPRG102.Final.Roland.BLL;
using CPRG102.Final.Roland.Data;
using CPRG102.Final.Roland.UI.HRData;
using CPRG102.Final.Roland.UI.Services;
using CPRG102.Final.Roland.UI.ViewModelFactories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CPRG102.Final.Roland.UI
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
            services.AddControllersWithViews();

            services.AddDbContext<HRContext, HRContext>(o => o.UseSqlServer(Configuration.GetConnectionString("HR")));
            services.AddDbContext<AssetContext, AssetContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Assets")));

            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddTransient<IAssetViewModelFactory, AssetViewModelFactory>();
            services.AddTransient<IAssignmentPageViewModelFactory, AssignmentPageViewModelFactory>();
            services.AddTransient<IAssetService, AssetService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Asset/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Asset}/{action=Index}/{id?}");
            });
        }
    }
}
