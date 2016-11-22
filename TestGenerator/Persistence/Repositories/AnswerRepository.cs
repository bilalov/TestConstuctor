using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class AnswerRepository: IAnswerRepository
    {
        private readonly IApplicationDbContext _context;

        public AnswerRepository(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}