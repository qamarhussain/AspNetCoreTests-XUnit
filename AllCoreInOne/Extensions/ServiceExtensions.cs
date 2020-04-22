using AllCoreInOne.Data;
using AllCoreInOne.Models;
using AllCoreInOne.Services.CurrentUser;
using AllCoreInOne.Services.Email;
using AllCoreInOne.Services.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AllCoreInOne.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ICurrentUser, CurrentUserService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        public static void ConfigureIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<Data.ApplicationDbContext>();
        }



    }
}
