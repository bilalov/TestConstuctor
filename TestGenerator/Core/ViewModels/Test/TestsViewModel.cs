using System.Collections.Generic;

namespace TestGenerator.Core.ViewModels.Test
{
    public class TestsViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<Models.Test.Test> Tests { get; set; }
    }
}