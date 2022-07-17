using System.Collections.Generic;
using DataObjects;
using Utilities;

namespace DataHelper
{
    public class AssignmentAPIHelper : IAssignmentAPIHelper
    {
        IRestAPIHelper _restAPIHelper;

        public AssignmentAPIHelper(IRestAPIHelper restAPIHelper)
        {
            _restAPIHelper = restAPIHelper; 
        }
        public List<Assignment> GetAssignments(Dictionary<string, string> parameters)
        {
            List<Assignment> assignments = new List<Assignment>();
            
            string json = _restAPIHelper.GetData(parameters);

            assignments = Common.ConvertJSONToList<Assignment>(json);
            return assignments;
        }
    }
}
