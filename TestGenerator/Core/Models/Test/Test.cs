using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TestGenerator.Core.Models.Test
{
    public class Test
    {
        public int Id { get; set; }

        public ApplicationUser Operator { get; set; }

        [Required]
        public string OperatorId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Название теста:")]
        public string Name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Описание теста:")]
        public string Description { get; set; } = string.Empty;

        public DateTime DateTime { get; set; } = System.DateTime.Now;

        
        [Display(Name = "Статус теста::")]
        public TestStatus TestStatus { get; set; }

        [Required]
        public byte TestStatusId { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<TestResult> Results { get; set; } = new List<TestResult>();

        public ICollection<PermissionForTest> Permissions { get; private set; }

        public Test()
        {
            Permissions = new Collection<PermissionForTest>();
        }

        public void Modify(Test test)
        {
            Name = test.Name;
            TestStatusId = test.TestStatusId;
            Questions = test.Questions;
        }

        public TestResult CalculateMatch(Test test1)
        {
            var answers = test1.Questions.SelectMany(q => q.Answers).ToList();
            var trueAnswer = 0;
            var allAnswers = Questions.Count;

            foreach (var question in Questions)
            {
                if (question.QuestionTypeId == 1)
                {
                    for (int i = 0; i < question.Answers.Count; i++)
                    {

                        if (question.Answers[i].Value != answers.Single(a => a.Id == question.Answers[i].Id).Value)
                        {
                            break;
                        }
                        if (i == (question.Answers.Count - 1))
                        {
                            trueAnswer++;
                        }
                    }
                }
                else if (question.QuestionTypeId == 2)
                {
                    if (question.Answers.Single().Value ==
                        answers.Single(a => a.Id == question.Answers.Single().Id).Value)
                    {
                        trueAnswer++;
                    }
                }

            }

            var result = new TestResult(test1.Id, trueAnswer, allAnswers);
            return result;
        }
    }
}