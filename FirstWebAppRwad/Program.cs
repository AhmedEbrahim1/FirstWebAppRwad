namespace FirstWebAppRwad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSession(option =>
            {
                option.IOTimeout = TimeSpan.FromMinutes(50);
            });
            builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            #region Built in Middleware


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            //controller Name = department  action name =index
            app.UseRouting();
            //user name and password 
            //app.UseAuthentication();
            //authoized 
            // app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
        // pattern: "{controller=Home}/{action=Index}/{id?}");
                pattern: "{controller=Department}/{action=Index}/{id?}");
            // pattern: "{controller=Home}/{action=Index}/{name?}");
            app.Run();


            #endregion


            #region custome middleware

            //use => execute call next middleware
            //run =>execute terminate 
            //map


            //app.Use(async (context, next) =>
            //{
            //    // context.Response = "1-middleware";
            //    await context.Response.WriteAsync("first middleware \n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("first middleware ---------- \n ");
            //});

            //app.Use(async (context, next) =>
            //{
            //    // context.Response = "1-middleware";
            //    await context.Response.WriteAsync("Second Middleware middleware \n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("second middleware ---------- \n ");

            //});

            //app.Run( async (context) =>
            //{
            //   await context.Response.WriteAsync("third middleware \n");
            //});

            ////cannot be called 
            //app.Use(async (context, next) =>
            //{
            //    // context.Response = "1-middleware";
            //    await context.Response.WriteAsync("four Middleware middleware \n");
            //    await next.Invoke();
            //});
            //app.Use(async (context, next) =>
            //{
            //    // context.Response = "1-middleware";
            //    await context.Response.WriteAsync("five Middleware middleware \n");
            //    await next.Invoke();
            //});
            //app.Run();

            #endregion


            // built int middleware
            //custome middileware
        }
    }
}
