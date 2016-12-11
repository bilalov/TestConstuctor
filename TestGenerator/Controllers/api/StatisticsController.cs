using System.Web.Http;
using TestGenerator.Core;

namespace TestGenerator.Controllers.api
{
    [System.Web.Http.Authorize]
    public class StatisticsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatisticsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
    }
}
