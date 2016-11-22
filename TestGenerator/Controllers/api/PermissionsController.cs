using Microsoft.AspNet.Identity;
using System.Web.Http;
using TestGenerator.Core;
using TestGenerator.Core.Models.Test;

namespace TestGenerator.Controllers.api
{
    /*[Authorize]
    public class PermissionsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult GetAccessRequest(int testId)
        {
            var userId = User.Identity.GetUserId();

            var permission = _unitOfWork.Permissions.GetPermission(userId, testId);
            if (permission != null)
                return BadRequest("Permission already exists.");

            permission = new PermissionForTest()
            {
                TestId = testId,
                UserId = userId,
                Type = PermissionType.InWait
            };

            _unitOfWork.Permissions.Add(permission);
            _unitOfWork.Complete();

            return Ok();
        }
    }*/

    [Authorize]
    public class PermissionsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Add(PermissionDto dto)
        {
            var userId = User.Identity.GetUserId();

            var permission = _unitOfWork.Permissions.GetPermission(userId, dto.TestId);
            if (permission != null)
                return BadRequest("Permission already exists.");

            permission = new PermissionForTest()
            {
                TestId = dto.TestId,
                UserId = userId,
                Type = PermissionType.InWait
            };

            _unitOfWork.Permissions.Add(permission);
            _unitOfWork.Complete();

            return Ok();
        }

    }

    public class PermissionDto
    {
        public int TestId { get; set; }
    }
}