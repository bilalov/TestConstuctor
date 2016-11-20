using System.Collections.Generic;
using System.Web.Mvc;
using TestGenerator.Core;
using TestGenerator.Core.ViewModels;

namespace TestGenerator.Controllers
{
    public class TestsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActionResult Create()
        {
            var viewModel = new TestFormViewModel
            {
                Heading = "Создать тест",
                TestStatuses = _unitOfWork.TestStatuses.GetStatuses(),
                Questions = new List<QuestionFormViewModel>()
                {
                    new QuestionFormViewModel()
                    {
                       QuestionTypes = _unitOfWork.QuestionTypes.GetTypes(),
                       Answers = new List<AnswerFormViewModel>()
                       {
                           new AnswerFormViewModel()
                           {
                               
                           }
                       }
                    }
                }
            };

            return View("Create", viewModel);
        }
    }
}