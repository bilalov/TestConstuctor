﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels.Test
{
    public class QuestionFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Текст вопроса:")]
        public string Text { get; set; }

        public byte QuestionTypeId { get; set; }

        public IEnumerable<QuestionType> QuestionTypes { get; set; }

        public HttpPostedFileBase Image { get; set; }

        //public MemoryPostedFile Image2 { get; set; }

        public List<AnswerFormViewModel> Answers { get; set; } = new List<AnswerFormViewModel>();

        
    }
}