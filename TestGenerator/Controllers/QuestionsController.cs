using System.Web.Mvc;
using TestGenerator.Core;
using TestGenerator.Core.ViewModels;

namespace TestGenerator.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var myModel = new QuestionFormViewModel()
            {
               QuestionTypes = _unitOfWork.QuestionTypes.GetTypes()
            };

            return PartialView("QuestionForm", myModel);
        }
    }
}