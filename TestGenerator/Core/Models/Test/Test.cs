using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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

        public int CalculateMatch(Test test1)
        {
            return 0;
        }
    }
}