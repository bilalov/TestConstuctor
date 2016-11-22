using System.Collections.Generic;
using System.Linq;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.Repositories;

namespace TestGenerator.Persistence.Repositories
{
    public class QuestionTypeRepository: IQuestionTypeRepository
    {
        private readonly IApplicationDbContext _context;

        public QuestionTypeRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<QuestionType> GetTypes()
        {
            return _context.QuestionTypes.ToList();
        }
    }
}
