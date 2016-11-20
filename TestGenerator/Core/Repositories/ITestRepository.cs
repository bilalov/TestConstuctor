using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.Repositories
{
    public interface ITestRepository
    {
        void Add(Test test);
        IEnumerable<Test> GetTestsByOperator(string operatorId);
    }
}
