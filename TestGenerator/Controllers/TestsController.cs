using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using TestGenerator.Core;
using TestGenerator.Core.Models.Test;
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

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new TestFormViewModel
            {
                Heading = "Создать тест",
                TestStatuses = _unitOfWork.TestStatuses.GetStatuses(),
                TypeQuestions = _unitOfWork.QuestionTypes.GetTypes()
            };

            return View("Create", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Создать тест";
                viewModel.TestStatuses = _unitOfWork.TestStatuses.GetStatuses();
                viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();
                return View("Create", viewModel);
            }

            var test = new Test
            {
                OperatorId = User.Identity.GetUserId(),
                DateTime = DateTime.Now,
                TestStatusId = viewModel.TestStatus,
                Description = viewModel.Description,   
                Name  = viewModel.Name
            };

            _unitOfWork.Tests.Add(test);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ViewResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _unitOfWork.Tests.GetTestsByOperator(userId);

            return View(gigs);
        }
    }
}