using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels.Test
{
    public class TestPassingViewModel
    {
        public string Heading { get; set; }

        public int Id { get; set; }

        [Required]
        [DisplayName("Статус теста:")]
        public byte TestStatusId { get; set; }

        public IEnumerable<TestStatus> TestStatuses { get; set; }
        public IEnumerable<QuestionType> TypeQuestions { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Название теста:")]
        public string Name { get; set; }

        [StringLength(1000)]
        [DisplayName("Описание теста:")]
        public string Description { get; set; }

        public List<QuestionPassingViewModel> Questions { get; set; } = new List<QuestionPassingViewModel>();
    }
}