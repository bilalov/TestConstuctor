using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class TestRepository: ITestRepository
    {
        private readonly IApplicationDbContext _context;

        public TestRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Test test)
        {
            _context.Tests.Add(test);
        }

        public IEnumerable<Test> GetTestsByOperator(string operatorId)
        {
            return _context.Tests
               .Where(t =>
                   t.OperatorId == operatorId)
               .Include(t => t.TestStatus)
               .ToList();
        }

        public IEnumerable<Test> GetAllTest()
        {
            var tests = _context.Tests
                .Include(g => g.Operator)
                .Include(g => g.TestStatus).ToList();

            return tests;
        }

        public IEnumerable<Test> GetActiveTests(string getUserId)
        {
            return _context.Tests
                .Where(t => t.TestStatusId == 1)
                .Include(g => g.Operator)
                .Include(g => g.TestStatus)
                .ToList();
        }

        public IEnumerable<Test> GetUnsolicitedTest(string userId)
        {
            var solicitedTest = GetSolicitedTest(userId).Select(x => x.Id).ToList();
            var waitingTest = GetWaitingTest(userId).Select(x => x.Id);
            solicitedTest.AddRange(waitingTest);
            var tests = _context.Tests
                .Where(t => t.TestStatusId == 1)
                .Where(x => !solicitedTest.Contains(x.Id))
                .Include(g => g.TestStatus)
                .Include(t => t.Operator)
                .ToList();
            return tests;
        }

        public IEnumerable<Test> GetSolicitedTest(string userId)
        {
            return _context.Permissions
               .Where(a => a.UserId == userId && a.Type == PermissionType.AccessAllowed)
               .Select(a => a.Test).Where(t => t.TestStatusId == 1)
               .Include(g => g.TestStatus)
               .Include(t => t.Operator)
               .ToList();
        }

        public IEnumerable<Test> GetWaitingTest(string userId)
        {
            return _context.Permissions
               .Where(a => a.UserId == userId && a.Type != PermissionType.AccessAllowed)
               .Select(a => a.Test).Where(t => t.TestStatusId == 1)
               .Include(g => g.TestStatus)
               .Include(t => t.Operator)
               .ToList();
        }
    }
}