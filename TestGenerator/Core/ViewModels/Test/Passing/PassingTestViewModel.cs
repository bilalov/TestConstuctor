using System.Collections.Generic;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels.Test.Passing
{
    public class PassingTestViewModel
    {
        public int Id { get; set; }
        public IEnumerable<QuestionType> TypeQuestions { get; set; }

        public string Name { get; set; }

        public List<QuestionFormViewModel> Questions { get; set; } = new List<QuestionFormViewModel>();
    }
}