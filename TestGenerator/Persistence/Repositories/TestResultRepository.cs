using System.Data.Entity.Migrations;
using System.Linq;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class TestResultRepository:ITestResultRepository
    {
        private readonly IApplicationDbContext _context;

        public TestResultRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TestResult testResult)
        {
            
        }

        public void AddOrUpdate(TestResult testResult)
        {
            var result = _context.TestResults
                .SingleOrDefault(x => x.TestId == testResult.TestId && x.UserId == testResult.UserId);
            if (result == null)
            {
                _context.TestResults.Add(testResult);
            }
            else
            {
                testResult.Id = result.Id;
                _context.TestResults.AddOrUpdate(testResult);
            }
            
        }

        public TestResult Get(int testId, string userId)
        {
            return _context.TestResults.SingleOrDefault(x => x.TestId == testId && x.UserId == userId);
        }
    }
}