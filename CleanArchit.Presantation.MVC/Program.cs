using CleanArchit.Presantation.MVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CleanArchit.Infrastructure.Data.Context;
using CleanArchit.Infrastructure.IoC;
using CleanArchit.Presantation.MVC.Services.Interfaces;
using CleanArchit.Presantation.MVC.Services.Services;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Authorization;
using CleanArchit.Presantation.MVC.Models;

namespace CleanArchit.Presantation.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            var connectionStringDbStudent = builder.Configuration.GetConnectionString("StudentConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<StudentDBContext>(options =>
          options.UseSqlServer(connectionStringDbStudent));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<TeacherIdentity>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddTransient<ICounter, CounterStudentService>();
           
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            });
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddControllersWithViews();
            RegisterServices(builder.Services);

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1800);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddDirectoryBrowser();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseRouting();  
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.Run();
        }
        private static void RegisterServices(IServiceCollection services) 
        {
            DependencyContainer.RegisterServices(services);
        }


    }
}