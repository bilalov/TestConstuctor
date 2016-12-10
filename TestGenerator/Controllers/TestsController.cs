using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestGenerator.Core;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.ViewModels;
using TestGenerator.Core.ViewModels.Test;

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

        public ActionResult Create()
        {
            var questions = new List<QuestionFormViewModel>()
            {
                new QuestionFormViewModel()
                {
                    Text = "Первый вопрос",
                    QuestionTypes = _unitOfWork.QuestionTypes.GetTypes(),
                    Answers = new List<AnswerFormViewModel>()
                    {
                        new AnswerFormViewModel()
                        {
                            Caption = "Ответ 1",
                            Value = false
                        }
                    }
                }
            };
            var viewModel = new TestFormViewModel
            {
                Heading = "Создать тест",
                TestStatuses = _unitOfWork.TestStatuses.GetStatuses(),
                TypeQuestions = _unitOfWork.QuestionTypes.GetTypes(),
                Questions = questions
               
            };

            return View("TestForm", viewModel);
        }

        public ActionResult Passing(int id)
        {
            var test = _unitOfWork.Tests.GetTestWithPermissions(id);

            if (test == null)
                return HttpNotFound();

            if (test.TestStatus.Name != "Опубликовано")
                return new HttpUnauthorizedResult();

            var userId = User.Identity.GetUserId();

            if (test.Permissions.SingleOrDefault(t=>t.UserId == userId) == null)
                return new HttpUnauthorizedResult();

            var viewModel = Mapper.Map<Test, TestPassingViewModel>(test);
            viewModel.Heading = "Прохождение теста";
            viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();

            return View("Passing", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Создать тест";
                viewModel.TestStatuses = _unitOfWork.TestStatuses.GetStatuses();
                viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();
                return View("TestForm", viewModel);
            }
            var test = Mapper.Map<TestFormViewModel, Test>(viewModel);
            test.OperatorId = User.Identity.GetUserId();

            _unitOfWork.Tests.Add(test);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

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
            var permissions = _unitOfWork.Permissions.GetPermissionsByUser(userId);

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
            var permissions = _unitOfWork.Permissions.GetPermissionsByUser(userId);

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
            var permissions = _unitOfWork.Permissions.GetPermissionsByUser(userId);

            var viewModel = new TestsForUserViewModel()
            {
                Heading = "Ограниченные тесты",
                Tests = waitingTests,
                Permissions = permissions.ToLookup(a => a.TestId)
            };

            return View("Waiting", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TestFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Heading = "Создать тест";
                viewModel.TestStatuses = _unitOfWork.TestStatuses.GetStatuses();
                viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();
                var test2 = Mapper.Map<TestFormViewModel, Test>(viewModel);
                var viewModel2 = Mapper.Map<Test, TestPassingViewModel>(test2);
                return View("TestEdit", viewModel2);
            }

            var test = _unitOfWork.Tests.GetTest(viewModel.Id);

            if (test == null)
                return HttpNotFound();

            if (test.OperatorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            

            var test1 = Mapper.Map<TestFormViewModel, Test>(viewModel);
            test1.OperatorId = User.Identity.GetUserId();

            test.Modify(test1);

            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Tests");
        }


        public ActionResult Edit(int id)
        {
            var test = _unitOfWork.Tests.GetTest(id);

            if (test == null)
                return HttpNotFound();

            if (test.OperatorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = Mapper.Map<Test, TestPassingViewModel>(test);
            viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();
            viewModel.Heading = "Редактирование теста";
            viewModel.TestStatuses = _unitOfWork.TestStatuses.GetStatuses();
            viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();

            return View("TestEdit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(TestFormViewModel viewModel)
        {
            var test = _unitOfWork.Tests.GetTestWithPermissions(viewModel.Id);

            if (test == null)
                return HttpNotFound();

            if (test.TestStatus.Id != 1)
                return new HttpUnauthorizedResult();

            var userId = User.Identity.GetUserId();

            if (test.Permissions.SingleOrDefault(t => t.UserId == userId) == null)
                return new HttpUnauthorizedResult();

            var test1 = Mapper.Map<TestFormViewModel, Test>(viewModel);

            var result = test.CalculateMatch(test1);
            result.UserId = userId;
            result.TestId = test.Id;

            _unitOfWork.TestResults.Add(result);
            _unitOfWork.Complete();

            return View("Result", result);
        }
    }
}