using RestauranteQR.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RestauranteQR
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
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
             opciones =>
             {
                 opciones.LoginPath = "/Login/Login";
                 opciones.AccessDeniedPath = "/Login/NoAutorizado";
                 opciones.LogoutPath = "/Login/Salir";
                 opciones.ExpireTimeSpan = System.TimeSpan.FromMinutes(10);
             }
         );
        services.AddControllersWithViews();
        //services.AddDbContext<RestoDbContext>(options => options.UseSqlite(@"Data Source=/Users/fidustap/ORT/2Cuat/NT1/RestauranteQR/RestauranteQR/BaseDatos/IngredienteTabla.db")); den
        services.AddDbContext<RestoDbContext>(options => options.UseSqlite(@"filename=C:\Users\matih\OneDrive\Escritorio\ORT\PROGRAMACION EN NUEVAS TECNOLOGIAS 1\NT1-RestauranteQR\RestauranteQR\BaseDatos\IngredienteTabla.db")); //mati
        //services.AddDbContext<RestoDbContext>(options => options.UseSqlite(@"filename=C:\Users\malu2\source\repos\NT1-RestauranteQR\RestauranteQR\BaseDatos\IngredienteTabla.db")); //malu
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
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });

        app.UseCookiePolicy();
    }
}
}
