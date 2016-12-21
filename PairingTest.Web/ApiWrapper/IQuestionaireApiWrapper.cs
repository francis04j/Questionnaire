using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PairingTest.Web.ApiWrapper.Models;

namespace PairingTest.Web.ApiWrapper
{
    public interface IQuestionaireApiWrapper
    {
        Task<QuestionairesResultModel> GetQuestions();
    }
}
