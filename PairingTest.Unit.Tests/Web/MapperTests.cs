using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PairingTest.Web.ApiWrapper.Models;
using PairingTest.Web.ModelMappers;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class MapperTests
    {
        readonly IMapper mapper;

        public MapperTests()
        {
            this.mapper = new Mapper();
        }

        [Test]
        public void CanMapApiResultModelToViewModel()
        {
            var apiModel = new QuestionairesResultModel()
            {
                QuestionnaireTitle = "QuestionnaireTitle",
                QuestionsText = new List<string>() {"QuestionText", "QuestionText1"}
            };
            var viewModel= mapper.MapFrom(apiModel);

            Assert.IsNotNull(viewModel);
            Assert.AreEqual(apiModel.QuestionnaireTitle, viewModel.QuestionnaireTitle);
            Assert.IsTrue(apiModel.QuestionsText.Any());
        }
    }
}
