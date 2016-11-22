using Microsoft.AspNet.Identity;
using System.Web.Http;
using TestGenerator.Core;
using TestGenerator.Core.Models.Test;
using TestGenerator.Helpers;

namespace TestGenerator.Controllers.api
{
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

        [HttpPut]
        public IHttpActionResult Update(PermissionUpdateDto dto)
        {
            var userId = User.Identity.GetUserId();

            var permission = _unitOfWork.Permissions.GetPermission(dto.UserId, dto.TestId);
            if (permission == null)
                return BadRequest("Permission doesn't exists.");

            if(permission.Test.OperatorId != User.Identity.GetUserId())
                return BadRequest("You don't allow to this operation");

            permission.Type = PermissionTypesDisplayConventer.dict[dto.Type];

            _unitOfWork.Permissions.Update(permission);
            _unitOfWork.Complete();

            return Ok();
        }

    }

    public class PermissionUpdateDto
    {
        public int TestId { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
    }

    public class PermissionDto
    {
        public int TestId { get; set; }
    }
}