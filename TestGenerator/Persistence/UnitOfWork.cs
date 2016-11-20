using TestGenerator.Core;
using TestGenerator.Core.Repositories;
using TestGenerator.Persistence.Repositories;

namespace TestGenerator.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Answers = new AnswerRepository(context);
            Questions = new QuestionRepository(context);
            Users = new ApplicationUserRepository(context);
            Tests = new TestRepository(context);
            TestStatuses = new TestStatusRepository(context);            
        }

        public IAnswerRepository Answers { get; }
        public IQuestionRepository Questions { get; }
        public IApplicationUserRepository Users { get; }
        public ITestRepository Tests { get; }
        public ITestStatusRepository TestStatuses { get; }

        public void Complete()
        {
            
        }
    }
}