using System;
using PairingTest.Web.ApiWrapper.Models;
using PairingTest.Web.Models;

namespace PairingTest.Web.ModelMappers
{
    public interface IMapper
    {
        QuestionnaireViewModel MapFrom(QuestionairesResultModel apiModel);
    }
}
