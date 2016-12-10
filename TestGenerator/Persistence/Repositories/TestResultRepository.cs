using System.Data.Entity.Migrations;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class TestResultRepository:ITestResult
    {
        private readonly IApplicationDbContext _context;

        public TestResultRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(TestResult testResult)
        {
            _context.TestResults.Add(testResult);
        }

        public void Update(TestResult testResult)
        {
            _context.TestResults.AddOrUpdate(testResult);
        }
    }
}