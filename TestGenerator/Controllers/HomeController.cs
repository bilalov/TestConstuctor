using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TestGenerator.Core;
using TestGenerator.Core.ViewModels;
using TestGenerator.Core.ViewModels.Test;

namespace TestGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var tests = _unitOfWork.Tests.GetAllTest();

            var userId = User.Identity.GetUserId();

            var viewModel = new TestsViewModel
            {
                Tests = tests,
                Heading = "Все тесты",
            };

            return View("Tests", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}