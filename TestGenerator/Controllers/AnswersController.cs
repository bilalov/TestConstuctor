using System.Web.Mvc;
using TestGenerator.Core.ViewModels;

namespace TestGenerator.Controllers
{
    public class AnswersController : Controller
    {
        // GET: Answers
        [HttpGet]
        public ActionResult Create()
        {
            var myModel = new AnswerFormViewModel();
            {
                
            };

            return PartialView("View", myModel);
        }
    }
}