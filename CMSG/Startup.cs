using CMSG.BL.Interface;
using CMSG.BL.Mapper;
using CMSG.BL.Repository;
using CMSG.DAL.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSG
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

            services.AddDbContextPool<dbContainer>(opts => 
            opts.UseSqlServer(Configuration.GetConnectionString("CmsDbConnection")));

            //===========================================================================================
            services.AddIdentity<IdentityUser, IdentityRole>(options => {

                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

            }).AddEntityFrameworkStores<dbContainer>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);
            //===========================================================================================

            //services.AddTransient<DepartmentRep>();       1 ===> Take Instance Every Request
            //services.AddScoped<DepartmentRep>();      //  2 ===> Take One Instance For Each User
            //services.AddSingleton<DepartmentRep>();       3 ===> Take Shared Instance For All Users   // used if landing page without ops or static

            services.AddScoped<IDepartmentRep, DepartmentRep>();            // D Inversion
            services.AddScoped<IEmployeeRep, EmployeeRep>();

            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
