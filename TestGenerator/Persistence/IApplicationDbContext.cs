using System.Data.Entity;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Answer> Answers { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<TestStatus> TestStatuses { get; set; }
        DbSet<QuestionType> QuestionTypes { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<PermissionForTest> Permissions { get; set; }

    }
}
