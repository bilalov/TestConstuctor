using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class AnswerRepository: IAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public AnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}