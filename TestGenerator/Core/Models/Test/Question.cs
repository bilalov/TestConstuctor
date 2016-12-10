using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestGenerator.Core.Models.Test
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Текст вопроса:")]
        public string Text { get; set; }

        [Required]
        public byte QuestionTypeId { get; set; }

        [Display(Name = "Тип теста:")]
        public QuestionType QuestionType { get; set; }

        public byte[] Image { get; set; }

        public IList<Answer> Answers { get; set; } 
    }
}