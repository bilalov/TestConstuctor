using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TestGenerator.Core.Models;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TestStatus> TestStatuses { get; set; }
        public DbSet<Test> Tests { get; set; } 

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}