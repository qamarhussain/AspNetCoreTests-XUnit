using AllCoreInOne.Data;
using AllCoreInOne.Services.CurrentUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.AuthorizationPolicy
{
    public class AuthorizationPolicyService : IAuthorizationPolicy
    {
        private ICurrentUser CurrentUser { get; }
        private ApplicationDbContext ApplicationDbContext { get; }
        
        public AuthorizationPolicyService(
            ICurrentUser currentUser,
            ApplicationDbContext applicationDbContext)
        {
            CurrentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            ApplicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<bool> GrantsEmployeeAccess(Guid employeeId)
        {
            var employee = await FetchEntity<Models.Employee>(x => x.Id == employeeId);
            return employee.CreatedBy == CurrentUser.Id;
        }

        private Task<TEntity> FetchEntity<TEntity>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> includes = null)
            where TEntity : class
        {
            var query = ApplicationDbContext.Set<TEntity>()
                .AsNoTracking()
                .AsQueryable();
            if (includes != null)
            {
                query = query.Include(includes);
            }

            return query.SingleOrDefaultAsync(filter);
        }
    }
        
    public static class ContainerBuilderExtensions
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services) =>
            services
                .AddScoped<IAuthorizationPolicy, AuthorizationPolicyService>();
    }

}