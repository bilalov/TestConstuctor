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

        public void Remove(ApplicationUser user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.Users
                .Include(g => g.Roles).ToList();
        }

        public IEnumerable<ApplicationUser> GetUnActivateUsers()
        {
            return _context.Users
                .Include(u => u.Roles)
                .Where(u => !u.IsApproved)
                .ToList();
        }

        ApplicationUser IApplicationUserRepository.GetUser(string userId)
        {
            return _context.Users
                .SingleOrDefault(u => u.Id == userId);
        }
    }
}