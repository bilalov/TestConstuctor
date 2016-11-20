using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestGenerator.Core.Models;
using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class ApplicationUserRepository: IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(string nickname)
        {
            return _context.Users
                  .Include(g => g.Roles)
                  .SingleOrDefault(g => g.NickName == nickname);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.Users
                .Include(g => g.Roles).ToList();
        }
    }
}