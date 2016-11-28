using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
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
                return View("TestForm", viewModel);
            }

            AutoMapper.Mapper.CreateMap<TestFormViewModel, Test>();
            AutoMapper.Mapper.CreateMap<QuestionFormViewModel, Question>();
            AutoMapper.Mapper.CreateMap<AnswerFormViewModel, Answer>();

            var test = Mapper.Map<TestFormViewModel, Test>(viewModel);
            test.OperatorId = User.Identity.GetUserId();

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
                return View("TestForm", viewModel);
            }

            var test = _unitOfWork.Tests.GetTest(viewModel.Id);

            if (test == null)
                return HttpNotFound();

            if (test.OperatorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            AutoMapper.Mapper.CreateMap<TestFormViewModel, Test>();
            AutoMapper.Mapper.CreateMap<QuestionFormViewModel, Question>();
            AutoMapper.Mapper.CreateMap<AnswerFormViewModel, Answer>();

            var test1 = Mapper.Map<TestFormViewModel, Test>(viewModel);
            test1.OperatorId = User.Identity.GetUserId();

            test.Modify(test1);

            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Tests");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var test = _unitOfWork.Tests.GetTest(id);

            if (test == null)
                return HttpNotFound();

            if (test.OperatorId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            AutoMapper.Mapper.CreateMap<Test, TestFormViewModel>();
            AutoMapper.Mapper.CreateMap<Question, QuestionFormViewModel>();
            AutoMapper.Mapper.CreateMap<Answer, AnswerFormViewModel>();

            var viewModel = Mapper.Map<Test, TestFormViewModel>(test);
            viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();
            viewModel.Heading = "Редактирование теста";
            viewModel.TestStatuses = _unitOfWork.TestStatuses.GetStatuses();
            viewModel.TypeQuestions = _unitOfWork.QuestionTypes.GetTypes();
            /* var viewModel = new GigFormViewModel
             {
                 Heading = "Edit a Gig",
                 Id = test.Id,
                 Genres = _unitOfWork.Genres.GetGenres(),
                 Date = test.DateTime.ToString("d MMM yyyy"),
                 Time = test.DateTime.ToString("HH:mm"),
                 Genre = test.GenreId,
                 Venue = test.Venue
             };*/

            return View("TestForm", viewModel);
        }
    }
}