using System.Collections.Generic;
using TestGenerator.Core.Models;

namespace TestGenerator.Core.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        IEnumerable<Role> GetUserRoles(string id);
        void Add(string userId, string role);
    }
}