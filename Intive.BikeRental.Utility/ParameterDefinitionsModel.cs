using System.Collections.Generic;
using System.Data.SqlClient;

namespace Intive.BikeRental.Utility
{
    public class ParameterDefinitionsModel
    {
        public ParameterDefinitionsModel()
        {
            ParameterDefinition = new List<SqlParameter>();
        }

        public IList<SqlParameter> ParameterDefinition { get; set; }

        public void AddParameter(SqlParameter sqlParameter)
        {
            ParameterDefinition.Add(sqlParameter);
        }
    }
}