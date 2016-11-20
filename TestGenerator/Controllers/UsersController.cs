using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TestGenerator.Core;

namespace TestGenerator.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Sort()
        {
           var test = _unitOfWork.Tests.GetActiveTests(User.Identity.GetUserId());

            return RedirectToAction("Index", "Home");
        }
    }
}