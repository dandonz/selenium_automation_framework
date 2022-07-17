using System.Data;
namespace DataHelper
{
    public interface IExcelDataHelper
    {
        public DataTable ReadData(string file);
        public void WriteData(DataTable data, string file);
    }
}
