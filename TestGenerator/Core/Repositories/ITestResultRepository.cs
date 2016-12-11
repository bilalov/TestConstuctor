using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.Repositories
{
    public interface ITestResultRepository
    {
        void Add(TestResult testResult);
        void AddOrUpdate(TestResult testResult);
        TestResult Get(int testId, string userId);
    }
}
