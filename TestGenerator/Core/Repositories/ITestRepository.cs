using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.Repositories
{
    public interface ITestRepository
    {
        void Add(Test test);
        IEnumerable<Test> GetTestsByOperator(string operatorId);
        IEnumerable<Test> GetAllTest();
        IEnumerable<Test> GetActiveTests(string getUserId);
        IEnumerable<Test> GetUnsolicitedTest(string userId);
        IEnumerable<Test> GetSolicitedTest(string userId);
        IEnumerable<Test> GetWaitingTest(string userId);
        Test GetTest(int id);
        void Remove(Test test);
        Test GetTestWithPermissions(int id);
    }
}
