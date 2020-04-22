
using System;
using System.Threading.Tasks;

namespace AllCoreInOne.Services.AuthorizationPolicy
{
    public interface IAuthorizationPolicy
    {
        Task<bool> GrantsEmployeeAccess(Guid employeeId);
    }
}
