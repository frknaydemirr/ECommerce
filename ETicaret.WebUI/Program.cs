using ECommerce.Data;
using ECommerce.Service.Abstract;
using ECommerce.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ETicaret.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //database iþlemleri için:

            builder.Services.AddDbContext<DatabaseContext>();

            //generic servis iþlemleri için:
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));



            //Session iþlemleri için: -> Servis olarak ekledik:
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "ETicaret.Session"; //çerez ismi
                options.Cookie.HttpOnly = true; //sadece http isteklerinde geçerli
                options.Cookie.IsEssential = true; //çerez zorunlu mu -> KALICI ÇEREZ
                options.IdleTimeout = TimeSpan.FromDays(1); //çerezin geçerlilik süresi
                options.IOTimeout = TimeSpan.FromMinutes(10); //çerezin geçerlilik süresi
            });


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
            AddCookie(x =>
            {
                x.LoginPath = "/Account/SignIn";
                x.AccessDeniedPath = "/AccessDenied";   //kullanýcýnýn yetkisi olmadýðýnda nereye yönlendirilecek
                x.Cookie.Name = "Account"; //çerez ismi
                x.Cookie.MaxAge = TimeSpan.FromDays(7); //çerezin geçerlilik süresi
                x.Cookie.IsEssential = true; //çerez zorunlu mu -> KALICI ÇEREZ
            });


            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role,"Admin"));
                x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin","User","Customer"));


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

            app.UseSession(); //sessin kullanma:


            app.UseAuthentication(); // önce oturum açma iþlemi yapýlacak

            app.UseAuthorization(); //sonra yetkilendirme iþlemi yapýlacak

            app.MapControllerRoute(
           name: "admin",
           pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
