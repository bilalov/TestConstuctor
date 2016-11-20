using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels
{
    public class TestsViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<Test> Tests { get; set; }
    }
}