using System;
using System.Collections.Generic;
using DataObjects; 
namespace DataHelper
{
    public interface IAssignmentAPIHelper
    {
        List<Assignment> GetAssignments(Dictionary<string, string> parameters);
    }
}
