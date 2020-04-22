using AllCoreInOne.Models;
using System;

namespace AllCoreInOne.Services.CurrentUser
{
    public class CurrentUserService : ICurrentUser
    {
        public Guid Id => Guid.TryParse(_user?.Id, out var id) ? id : Guid.Empty;

        public string Username => _user?.UserName;
        public string Email => _user?.Email;
        public string FirstName => _user?.FirstName;
        public string LastName => _user?.LastName;
        public string FullName => _user?.FullName;

        private ApplicationUser _user;

        public void SetUser(ApplicationUser user)
        {
            _user = user;
        }

    }
}