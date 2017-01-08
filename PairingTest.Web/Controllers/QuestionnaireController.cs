using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using PairingTest.Web.ApiWrapper;
using PairingTest.Web.ModelMappers;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
          /* ASYNC ACTION METHOD... IF REQUIRED... */
//        public async Task<ViewResult> Index()
//        {
//        }
        readonly IQuestionaireApiWrapper apiWrapper;
        readonly IMapper mapper;

        public QuestionnaireController(IQuestionaireApiWrapper apiWrapper, IMapper mapper)
        {
            this.apiWrapper = apiWrapper;
            this.mapper = mapper;
        }

        public async Task<ViewResult> Index()
        {
            var questions = await apiWrapper.GetQuestions();
            var viewModel= mapper.MapFrom(questions);
            return View(viewModel);
        }


        public async Task<JsonResult> Questionnaires()
        {
            var questions = await apiWrapper.GetQuestions();
            ICollection<string> s = new List<string>();
            
            return Json(questions, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Submit(QuestionnaireViewModel viewModel)
        {
           
            return View("Success");
        }
    }
}
