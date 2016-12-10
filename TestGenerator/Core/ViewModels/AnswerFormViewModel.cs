using System.ComponentModel.DataAnnotations;

namespace TestGenerator.Core.ViewModels
{
    public class AnswerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Текст:")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Правильный:")]
        public bool Value { get; set; }
    }
}