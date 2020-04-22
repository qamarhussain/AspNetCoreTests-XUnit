using AllCoreInOne.Models;
using AllCoreInOne.Services.CurrentUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LeaseCrunch.Web.Middleware.CurrentUser
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<ApplicationUser> userManager, ICurrentUser currentUser, ILogger<CurrentUserMiddleware> logger)
        {
            var user = await userManager.GetUserAsync(context.User);
            if (user != null)
            {
                logger.LogInformation($"Current User middleware called UserName {user?.Email}");
                currentUser.SetUser(user);
            }

            await _next.Invoke(context);
        }
    }

    public static class ContainerBuilderExtensions
    {
        public static IApplicationBuilder AddCurrentUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CurrentUserMiddleware>();
        }
    }
}