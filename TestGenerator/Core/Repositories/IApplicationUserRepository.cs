using System.Collections.Generic;
using TestGenerator.Core.Models;

namespace TestGenerator.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetUnActivateUsers();
        ApplicationUser GetUser(string userId);
        void Remove(ApplicationUser user);
    }
}
