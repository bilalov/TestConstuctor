﻿using System.Collections.Generic;
using System.Linq;
using TestGenerator.Core.Models.Test;
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

        public IEnumerable<TestStatus> GetStatuses()
        {
            return _context.TestStatuses.ToList();
        }
    }
}