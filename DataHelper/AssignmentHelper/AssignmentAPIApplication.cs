using System.Collections.Generic;
using Utilities;

namespace DataHelper
{
    public class AssignmentAPIApplication: IAssignmentAPIApplication
    {
        IAssignmentAPIHelper _assignmentAPIHelper; 
        public AssignmentAPIApplication(IAssignmentAPIHelper assignmentAPIHelper)
        {
            _assignmentAPIHelper = assignmentAPIHelper;
        }
        public void Run()
        {
            string baseurl = "https://danyspace-8aeea.firebaseio.com/";
            string request = "/customercleaner.json";
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add(API_PARAMETER.API_BASE_URL, baseurl);
            pairs.Add(API_PARAMETER.API_REQUEST, request);

            _assignmentAPIHelper.GetAssignments(pairs); 
        }
    }
}
