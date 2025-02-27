using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVCPRoject.Filters;
using MVCPRoject.Models;
using MVCPRoject.Repository;
using System.Drawing;

namespace MVCPRoject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Built in service (service alread register)
            //built in service need to register
            //global filter attribute
            //builder.Services.AddControllersWithViews(optios =>
            //{
            //    optios.Filters.Add(new HandelErrorAttribute());
            //});
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyContext>(options=>
            {
                //appsetting
                options.UseSqlServer(builder.Configuration.GetConnectionString("Cs")); 
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            

            //custom Service need to register
            builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
            builder.Services.AddScoped<IAccountRepository,AccountRepository>();






            var app = builder.Build();

            // Configure the HTTP request pipeline. Day3
            #region Custom (inline ) Midddleare
                //app.Use(async (httpcontext, next) =>
                //{
                //    await httpcontext.Response.WriteAsync("1- MiddleWare 1\n");
                //    await next();
                //    await httpcontext.Response.WriteAsync("1-1 MiddleWare 1-1\n");

                //});
                //app.Use(async (httpcontext, next) =>
                //{
                //    await httpcontext.Response.WriteAsync("2- MiddleWare 2\n");
                //    await next.Invoke();
                //    await httpcontext.Response.WriteAsync("2-2 MiddleWare 2_2\n");

                //});
                //app.Run(async(httpcontext) => {
                //    await httpcontext.Response.WriteAsync("3- MiddleWare Terminate 3\n");

                //});

                #endregion



            #region Built In Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");//the Last one
            }
            app.UseStaticFiles();

            app.UseRouting(); //Mapping (Securte ) 
            
            app.UseAuthentication();//Check Auth
           
            app.UseAuthorization();//role
            #region     Route
            //define route + Execute (Staff)
            //NAmed Convertion route
            //app.MapControllerRoute(
            //  name: "route1",
            //  pattern: "{controller=Home}/{action=Index}"//search action 
            //  );
            //{name:alpha}/{age:int:range(10,40)}",
            //app.MapControllerRoute(
            // name: "route2",
            // pattern: "m2",
            // new { controller = "Route", action = "Method2" });
            #endregion
            //---------------------------------------------------
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");
               
            #endregion

            app.Run();
        }
    }
}
