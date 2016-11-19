using System.ComponentModel.DataAnnotations;

namespace TestGenerator.Core.Models.Test
{
    public class TestStatus
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}