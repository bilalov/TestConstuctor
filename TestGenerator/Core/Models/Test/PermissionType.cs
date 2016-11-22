using System.ComponentModel.DataAnnotations;

namespace TestGenerator.Core.Models.Test
{
    public enum PermissionType
    {
        [Display(Name = "В ожидании")]
        InWait = 1,
        [Display(Name = "Доступ запрещен")]
        AccessDenied = 2,
        [Display(Name = "Доступ разрешен")]
        AccessAllowed = 3,
    }
}