using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestGenerator.Core.Models.Test
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public ICollection<Answer> Answers { get; set; } 
    }

    public enum QuestionType
    {
        AnswerChoosing = 1,
        AnswerWriting = 2
    }
}