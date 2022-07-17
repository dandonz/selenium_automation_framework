using System.Collections.Generic;
using System.Data;
using Utilities;
using DataObjects;

namespace DataHelper
{
    public class AssignmentExcelHelper: IAssignmentExcelHelper
    {
        IExcelDataHelper _excelDataHelper;

        public AssignmentExcelHelper(IExcelDataHelper excelDataHelper)
        {
            _excelDataHelper = excelDataHelper; 
        }
        public List<Assignment> GetAssignments(Dictionary<string, string> parameters)
        {
            string file = parameters[FILE.FILE_PATH];
            DataTable data = _excelDataHelper.ReadData(file);

            List<Assignment> assignments = Common.ConvertDataTableToList<Assignment>(data);
            return assignments; 
        }
    }
}
