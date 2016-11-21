using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using TestGenerator.Core;
using TestGenerator.Core.Dtos;

namespace TestGenerator.Controllers.api
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.Users.GetUser(id);

            if (user == null)
                return NotFound();

            _unitOfWork.Users.Remove(user);

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Add(AddingUserDto dto)
        {
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.Users.GetUser(dto.Id);

            if (user == null)
                return NotFound();

            var userRole = _unitOfWork.Roles.GetUserRoles(dto.Id);
            if (userRole.Any())
                return BadRequest("The user already has role.");

            _unitOfWork.Roles.Add(dto.Id, dto.Role);
           /* attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _unitOfWork.Attendances.Add(attendance);*/

            user.Approve();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
