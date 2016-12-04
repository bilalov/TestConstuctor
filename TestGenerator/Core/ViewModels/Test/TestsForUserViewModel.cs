using System.Collections.Generic;
using System.Linq;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels.Test
{
    public class TestsForUserViewModel
    {
        public IEnumerable<Models.Test.Test> Tests { get; set; }
        public ILookup<int, PermissionForTest> Permissions { get; set; }
        public string Heading { get; internal set; }
    }
}