﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels
{
    public class TestFormViewModel
    {
        public string Heading { get; set; }

        [Required]
        [DisplayName("Статус теста:")]
        public TestStatus TestStatus { get; set; }

        public IEnumerable<TestStatus> TestStatuses { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Название теста:")]
        public string Name { get; set; }

        [StringLength(1000)]
        [DisplayName("Описание теста:")]
        public string Description { get; set; }

        public ICollection<QuestionFormViewModel> Questions { get; set; }
    }
}