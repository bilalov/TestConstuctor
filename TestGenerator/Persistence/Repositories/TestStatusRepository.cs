using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class TestStatusRepository: ITestStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public TestStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}