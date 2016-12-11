using Microsoft.AspNet.Identity;
using System.Web.Http;
using TestGenerator.Core;

namespace TestGenerator.Controllers.api
{
    [Authorize]
    public class TestsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var userId = User.Identity.GetUserId();
            var test = _unitOfWork.Tests.GetTestWithPermissions(id);

            if (test == null)
                return NotFound();

            if (test.OperatorId != userId)
                return Unauthorized();

            _unitOfWork.Tests.Remove(test);

            _unitOfWork.Complete();

            return Ok();
        }




    }
}
