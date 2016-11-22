using System.Collections.Generic;
using System.Web.Mvc;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels
{
    public class PermissionsViewModel
    {
        public IEnumerable<PermissionForTest> Permissions { get; set; }
        public IList<SelectListItem> Types { get; set; }
        public string Heading { get; set; }
    }
}