using System.Collections.Generic;
using System.ComponentModel;
using TestGenerator.Core.Models;

namespace TestGenerator.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [DisplayName("Роль пользователя")]
        public byte Role { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public string NickName { get; set; }
        public string UserName { get; set; }
    }
}