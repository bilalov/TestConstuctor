using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.Repositories
{
    public interface ITestResult
    {
        void Add(TestResult testResult);
        void Update(TestResult testResult);
    }
}
