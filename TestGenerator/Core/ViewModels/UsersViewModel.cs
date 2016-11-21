using System.Collections.Generic;

namespace TestGenerator.Core.ViewModels
{
    public class UsersViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}