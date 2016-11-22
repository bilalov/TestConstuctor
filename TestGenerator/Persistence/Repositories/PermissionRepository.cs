using System.Collections.Generic;
using System.Linq;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class PermissionRepository:IPermissionRepository
    {
        private readonly IApplicationDbContext _context;

        public PermissionRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PermissionForTest> GetPermissions(string userId)
        {
            return _context.Permissions
               .Where(a => a.UserId == userId)
               .Where(p => p.Type != PermissionType.AccessAllowed)
               .ToList();
        }

        public PermissionForTest GetPermission(string userId, int testId)
        {
            return _context.Permissions
                .SingleOrDefault(p => p.TestId == testId && p.UserId == userId);
        }

        public void Add(PermissionForTest permission)
        {
            _context.Permissions.Add(permission);
        }
    }
}