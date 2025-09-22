using ECommerce.Data;
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

            //database i�lemleri i�in:

            builder.Services.AddDbContext<DatabaseContext>();

            //Session i�lemleri i�in: -> Servis olarak ekledik:
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "ETicaret.Session"; //�erez ismi
                options.Cookie.HttpOnly = true; //sadece http isteklerinde ge�erli
                options.Cookie.IsEssential = true; //�erez zorunlu mu -> KALICI �EREZ
                options.IdleTimeout = TimeSpan.FromDays(1); //�erezin ge�erlilik s�resi
                options.IOTimeout = TimeSpan.FromMinutes(10); //�erezin ge�erlilik s�resi
            });


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
            AddCookie(x =>
            {
                x.LoginPath = "/Account/SignIn";
                x.AccessDeniedPath = "/AccessDenied";   //kullan�c�n�n yetkisi olmad���nda nereye y�nlendirilecek
                x.Cookie.Name = "Account"; //�erez ismi
                x.Cookie.MaxAge = TimeSpan.FromDays(7); //�erezin ge�erlilik s�resi
                x.Cookie.IsEssential = true; //�erez zorunlu mu -> KALICI �EREZ
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


            app.UseAuthentication(); // �nce oturum a�ma i�lemi yap�lacak

            app.UseAuthorization(); //sonra yetkilendirme i�lemi yap�lacak

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
