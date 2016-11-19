using System.ComponentModel.DataAnnotations;

namespace TestGenerator.Core.Models.Test
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Caption { get; set; }

        [Required]
        public bool Value { get; set; }
    }
}