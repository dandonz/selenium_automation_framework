using System.IO;
using ExcelDataReader;
using System.Data;

namespace DataHelper
{
    public class ExcelDataHelper : IExcelDataHelper
    {
        public DataTable ReadData(string file)
        {
            FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
            //This is used to avoid an error. 
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (file.EndsWith(".xls"))
            {
                IExcelDataReader excelDataReader = ExcelReaderFactory.CreateBinaryReader(stream);
                DataSet data = excelDataReader.AsDataSet();
                DataTableCollection tables = data.Tables;
                DataTable dataTable = tables[0];
                return dataTable; 
            }
            if (file.EndsWith(".xlsx"))
            {
                IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                DataSet data = excelDataReader.AsDataSet();
                DataTableCollection tables = data.Tables;
                DataTable dataTable = tables[0];//Return only the first table
                return dataTable;
            }            
            return null;
        }

        public void WriteData(DataTable data, string file)
        {
            throw new System.NotImplementedException();
        }

    }
}
