using System;
using System.ComponentModel.DataAnnotations;

namespace TestGenerator.Core.Models.Test
{
    public class TestResult
    {

        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }

        public Test Test { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int TrueAnswers { get; private set; }

        [Required]
        public int AllAnswers { get; private set; }

        [Required]
        public byte Evaluation { get; private set; }

        private void GetEvaluation()
        {
            if (AllAnswers != 0)
            {
                var result = Convert.ToInt32(100*TrueAnswers/AllAnswers);

                if (result >= 70)
                    Evaluation = 5;
                else if (result >= 40)
                    Evaluation = 4;
                else if (result >= 30)
                    Evaluation = 3;
                else
                    Evaluation = 2;
            }
            else
            {
                Evaluation = 0;
            }
                
        }

        public TestResult(int testId, int trueAnswers, int allAnswers)
        {
            TestId = TestId;
            TrueAnswers = trueAnswers;
            AllAnswers = allAnswers;
            GetEvaluation();
        }

        public TestResult()
        {
            
        }
    }
}