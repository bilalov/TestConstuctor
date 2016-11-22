using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Helpers
{
    public static class PermissionTypesDisplayConventer
    {
        public static Dictionary<string, PermissionType> dict = new Dictionary<string, PermissionType> {
                { "Доступ запрещен", PermissionType.AccessDenied },
                { "В ожидании", PermissionType.InWait },
                { "Доступ разрешен", PermissionType.AccessAllowed },
            };
    }
}