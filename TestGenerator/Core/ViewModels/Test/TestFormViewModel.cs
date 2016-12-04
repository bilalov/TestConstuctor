using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using TestGenerator.Controllers;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Core.ViewModels.Test
{
    public class TestFormViewModel
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

        public List<QuestionFormViewModel> Questions { get; set; } = new List<QuestionFormViewModel>();

        public string Action
        {
            get
            {
                Expression<Func<TestsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<TestsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}