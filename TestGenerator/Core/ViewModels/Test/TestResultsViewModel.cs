using System.Collections.Generic;

namespace TestGenerator.Core.ViewModels.Test
{
    public class TestResultsViewModel
    {
        public string TestName { get; set; }
        public ICollection<TestResultViewModel> Result { get; set; } = new List<TestResultViewModel>();
    }
}