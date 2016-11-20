using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}