using System.Linq;
using System.Web.Mvc;
using TestGenerator.Core;
using TestGenerator.Core.ViewModels;

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
            var users = _unitOfWork.Users.GetUnActivateUsers();
            var roles = _unitOfWork.Roles.GetAllRoles();
            var userViewModels = users.Select(user => new UserViewModel()
            {
                NickName = user.NickName,
                UserName = user.UserName,
                Roles = roles,
                Id = user.Id
            }).ToList();

            var viewModel = new UsersViewModel()
            {
                Heading = "Управление новыми пользователями",
                Users = userViewModels,
            
            };

            return View("Sort", viewModel);
        }
    }
}