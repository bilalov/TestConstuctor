using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestGenerator.Core.Models;
using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList().Select(r => new Role()
            {
                Id = Convert.ToByte(r.Id), Name = r.Name
            }).ToList();
        }

        public IEnumerable<Role> GetUserRoles(string id)
        {
            var userRoles = _context.Roles.ToList();
            var userRoleNames = (from r in userRoles
                                 from u in r.Users
                                 where u.UserId == id
                                 select(new Role()
                                 {
                                     Id = Convert.ToByte(r.Id),
                                     Name = r.Name
                                 })).ToList();

            return userRoleNames;

        }

        public void Add(string userId, string role)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            UserManager.AddToRole(userId, role);
        }
    }
}