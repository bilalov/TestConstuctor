using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}