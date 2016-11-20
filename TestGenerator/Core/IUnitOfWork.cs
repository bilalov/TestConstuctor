using TestGenerator.Core.Repositories;

namespace TestGenerator.Core
{
    public interface IUnitOfWork
    {
        IAnswerRepository Answers { get; }
        IQuestionRepository Questions { get; }
        IApplicationUserRepository Users { get; }
        ITestRepository Tests { get; }
        ITestStatusRepository TestStatuses { get; }
        IQuestionTypeRepository QuestionTypes { get; }
        void Complete();
    }
}
