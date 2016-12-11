using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using TestGenerator.Core.Models.Test;
using TestGenerator.Helpers;

namespace TestGenerator.Core.ViewModels.Test.Passing
{
    public class QuestionPassingViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Текст вопроса:")]
        public string Text { get; set; }

        public byte QuestionTypeId { get; set; }

        public IEnumerable<QuestionType> QuestionTypes { get; set; }

        public MemoryPostedFile Image { get; set; }

        public List<AnswerFormViewModel> Answers { get; set; } = new List<AnswerFormViewModel>();

        public byte[] GetBytes()
        {
            byte[] imgData;

            using (var reader = new BinaryReader(Image.InputStream))
            {
                imgData = reader.ReadBytes(Image.ContentLength);
            }

            return imgData;
        }
    }
}