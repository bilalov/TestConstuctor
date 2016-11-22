using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TestGenerator.Core;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.ViewModels;
using TestGenerator.Helpers;

namespace TestGenerator.Controllers
{
    public class PermissionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult InWait()
        {
            var permissions = _unitOfWork.Permissions.GetPermissionsByOperator(User.Identity.GetUserId(), PermissionType.InWait);

            var viewModel = new PermissionsViewModel()
            {
                Types = EnumHelper.GetSelectList(typeof(PermissionType)),
                Permissions = permissions,
                Heading = "Активные заявки"
            };

            return View("Index",viewModel);
        }

        public ActionResult Allow()
        {
            var permissions = _unitOfWork.Permissions.GetPermissionsByOperator(User.Identity.GetUserId(), PermissionType.AccessAllowed);

            var viewModel = new PermissionsViewModel()
            {
                Types = EnumHelper.GetSelectList(typeof(PermissionType)),
                Permissions = permissions,
                Heading = "Разрешенные заявки"
            };
            viewModel.Types.Single(x => x.Text == PermissionTypesDisplayConventer.dict.FirstOrDefault(v => v.Value == PermissionType.AccessAllowed).Key).Selected = true;

            return View("Index", viewModel);
        }

        public ActionResult Deny()
        {
            var permissions = _unitOfWork.Permissions.GetPermissionsByOperator(User.Identity.GetUserId(), PermissionType.AccessDenied);

            var viewModel = new PermissionsViewModel()
            {
                Types = EnumHelper.GetSelectList(typeof(PermissionType)),
                Permissions = permissions,
                Heading = "Отклоненные заявки"
            };
            viewModel.Types.Single(x => x.Text == PermissionTypesDisplayConventer.dict.FirstOrDefault(v => v.Value == PermissionType.AccessDenied).Key).Selected = true;

            return View("Index", viewModel);
        }
    }
}