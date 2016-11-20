using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels
{
    public class QuestionFormViewModel
    {
        [Required]
        [StringLength(1000)]
        [Display(Name = "Текст вопроса:")]
        public string Text { get; set; }

        [Display(Name = "Тип:")]
        public QuestionType Type { get; set; }

        public IEnumerable<QuestionType> QuestionTypes { get; set; }

        public ICollection<AnswerFormViewModel> Answers { get; set; }
    }
}