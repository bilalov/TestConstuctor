using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        public IEnumerable<PermissionForTest> GetPermissionsByUser(string userId)
        {
            return _context.Permissions
               .Where(a => a.UserId == userId)
               .Where(p => p.Type != PermissionType.AccessAllowed)
               .ToList();
        }

        public IEnumerable<PermissionForTest> GetPermissionsByOperator(string userId, PermissionType type)
        {
            return _context.Permissions
                .Where(p => p.Type == type)
                .Include(p => p.Test)
                .Include(p => p.User)
                .Where(t => t.Test.OperatorId == userId)
                .ToList();
        }

        public PermissionForTest GetPermission(string userId, int testId)
        {
            return _context.Permissions
                .Include(p=>p.Test)
                .SingleOrDefault(p => p.TestId == testId && p.UserId == userId);
        }

        public void Update(PermissionForTest permission)
        {
            _context.Permissions.AddOrUpdate(permission);
        }

        public void Add(PermissionForTest permission)
        {
            _context.Permissions.Add(permission);
        }
    }
}