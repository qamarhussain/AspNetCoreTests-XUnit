using AllCoreInOne.Models;
using System;

namespace AllCoreInOne.Services.CurrentUser
{
    public interface ICurrentUser
    {
        Guid Id { get; }

        string Username { get; }
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }

        void SetUser(ApplicationUser user);
    }
}