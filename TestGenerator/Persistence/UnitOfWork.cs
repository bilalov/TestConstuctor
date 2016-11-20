﻿using TestGenerator.Core;
using TestGenerator.Core.Repositories;
using TestGenerator.Persistence.Repositories;

namespace TestGenerator.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Answers = new AnswerRepository(context);
            QuestionTypes = new QuestionTypeRepository(context);
            Questions = new QuestionRepository(context);
            Users = new ApplicationUserRepository(context);
            Tests = new TestRepository(context);
            TestStatuses = new TestStatusRepository(context);            
        }

        public IAnswerRepository Answers { get; }
        public IQuestionRepository Questions { get; }
        public IApplicationUserRepository Users { get; }
        public ITestRepository Tests { get; }
        public ITestStatusRepository TestStatuses { get; }
        public IQuestionTypeRepository QuestionTypes { get; }

        public void Complete()
        {
            
        }
    }
}