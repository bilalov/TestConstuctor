using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestGenerator.Core.Models.Test
{
    public class PermissionForTest
    {
        public Test Test { get; set; }

        public ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 1)]
        public int TestId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }

        public PermissionType Type { get; set; }
    }
}