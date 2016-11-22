using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.Repositories
{
    public interface IPermissionRepository
    {
        IEnumerable<PermissionForTest> GetPermissions(string userId);
        PermissionForTest GetPermission(string userId, int testId);
        void Add(PermissionForTest permission);
    }
}
