﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestGenerator.Core.Models.Test;
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
            var tests = _context.Tests
                .Include(g => g.Operator)
                .Include(g => g.TestStatus).ToList();

            return tests;
        }
    }
}