using System;
using System.Collections.Generic;
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
        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        
        [Display(Name = "Статус теста::")]
        public TestStatus TestStatus { get; set; }

        [Required]
        public byte TestStatusId { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}