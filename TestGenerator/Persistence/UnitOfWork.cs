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
            QuestionTypes = new QuestionTypeRepository(context);
            Questions = new QuestionRepository(context);
            Users = new ApplicationUserRepository(context);
            Tests = new TestRepository(context);
            TestStatuses = new TestStatusRepository(context);    
            Roles = new RoleRepository(context);   
            Permissions = new PermissionRepository(context);   
        }

        public IAnswerRepository Answers { get; }
        public IQuestionRepository Questions { get; }
        public IApplicationUserRepository Users { get; }
        public ITestRepository Tests { get; }
        public ITestStatusRepository TestStatuses { get; }
        public IQuestionTypeRepository QuestionTypes { get; }
        public IRoleRepository Roles { get; }
        public IPermissionRepository Permissions { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}