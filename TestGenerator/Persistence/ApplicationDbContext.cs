using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TestGenerator.Core.Models;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TestStatus> TestStatuses { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Test> Tests { get; set; } 
        public DbSet<PermissionForTest> Permissions { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionForTest>().
                HasRequired(a => a.Test).
                WithMany(g => g.Permissions).
                WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}