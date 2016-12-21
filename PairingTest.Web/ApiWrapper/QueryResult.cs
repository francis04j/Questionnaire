using System.Collections.Generic;
using Newtonsoft.Json;

namespace PairingTest.Web.ApiWrapper
{
    public class QueryResult
    {
        public HashSet<QueryError> Errors { get; set; }
        public QueryResult()
        {
            Errors = new HashSet<QueryError>();
        }
        
        public QueryResult(QueryError queryError)
        {
            AddError(queryError);
        }

        public QueryResult AddError(QueryError error)
        {
            Errors = Errors ?? new HashSet<QueryError>();
            Errors.Add(error);
            return this;
        }
    }

    public class QueryError
    {
        [JsonConstructor]
        public QueryError(string error)
        {
            Error = error;
        }

        public QueryError() { }
        public string Error { get; private set; }
    }
}