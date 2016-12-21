using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PairingTest.Web.ApiWrapper.Models
{
    public class QuestionairesResultModel : QueryResult
    {
        public QuestionairesResultModel(QueryError queryError)
			: base(queryError) { }
        public QuestionairesResultModel() { }
        public string QuestionnaireTitle { get; set; }
        
        public IList<string> QuestionsText { get; set; }
    }
}