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
    }
}
