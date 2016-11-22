using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.Repositories
{
    public interface IPermissionRepository
    {
        IEnumerable<PermissionForTest> GetPermissionsByUser(string userId);
        IEnumerable<PermissionForTest> GetPermissionsByOperator(string testId, PermissionType type);
        void Add(PermissionForTest permission);
        PermissionForTest GetPermission(string userId, int testId);
        void Update(PermissionForTest permission);
    }
}
