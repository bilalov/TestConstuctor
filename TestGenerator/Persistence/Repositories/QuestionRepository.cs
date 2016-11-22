using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly IApplicationDbContext _context;

        public QuestionRepository(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}