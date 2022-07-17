using System.Data;
namespace DataHelper
{
    public interface IMySQLHelper
    {
        public DataTable ReadData(string connectionString);
        public void WriteData(DataTable data, string file);
    }
}
