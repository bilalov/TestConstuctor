using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using TestGenerator.Core;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.ViewModels;

namespace TestGenerator.Controllers
{
    [Authorize]
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

        public ActionResult Solicite()
        {
            var userId = User.Identity.GetUserId();
            var solicitedTests = _unitOfWork.Tests.GetSolicitedTest(userId);
            var permissions = _unitOfWork.Permissions.GetPermissions(userId);

            var viewModel = new TestsForUserViewModel()
            {
                Heading = "Доступные тесты",
                Tests = solicitedTests, 
                Permissions = permissions.ToLookup(a => a.TestId)
            };

            return View("Solicite", viewModel);
        }

        public ActionResult Unsolicite()
        {
            var userId = User.Identity.GetUserId();
            var unsolicitedTests = _unitOfWork.Tests.GetUnsolicitedTest(userId);
            var permissions = _unitOfWork.Permissions.GetPermissions(userId);

            var viewModel = new TestsForUserViewModel()
            {
                Heading = "Недоступные тесты",
                Tests = unsolicitedTests,
                Permissions = permissions.ToLookup(a => a.TestId)
            };

            return View("Unsolicite", viewModel);
        }

        public ActionResult Waiting()
        {
            var userId = User.Identity.GetUserId();
            var waitingTests = _unitOfWork.Tests.GetWaitingTest(userId);
            var permissions = _unitOfWork.Permissions.GetPermissions(userId);

            var viewModel = new TestsForUserViewModel()
            {
                Heading = "Ограниченные тесты",
                Tests = waitingTests,
                Permissions = permissions.ToLookup(a => a.TestId)
            };

            return View("Waiting", viewModel);
        }
    }
}