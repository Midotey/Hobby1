using Hobby1.Data;
using Microsoft.EntityFrameworkCore;

namespace Hobby1
{
    public class Program
    {
        public static void Main(string[] args)
        {   ///TODO: Сделать месседжер.
            //1. Сделать базу.
                //1.1. Подключить гит и гитхаб. -d.
                //1.2. Сделать модели. -d.
                //1.3. Подключить бд и сделать репозитории. -d.
                //1.4. Убрать лишние представления. -... .
            //2. Функционал.
                //2.1. Сделать идентификацию, аутентификацию и авторизацию для пользователей.
                //2.2. ... .
            //3. ... .




            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(db =>
            {
                db.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
