namespace MVCPRoject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseRouting(); //Mapping

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
               
            #endregion

            app.Run();
        }
    }
}
