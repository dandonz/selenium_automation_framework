using System;
using System.Data;
using System.Data.Odbc;

namespace DataHelper
{
    public class MySQLHelper : IMySQLHelper
    {
        public DataTable ReadData(string connectionString)
        {
            //"Unable to load shared library 'libodbc.2.dylib' or one of its dependencies"
            //On Mac: "brew install unixodbc" to fix the above issue.
            //On My Computer: A driver version: "ODBC Driver 13 for SQL Server"
            DataTable dataTable = new DataTable();
            OdbcConnection odbcConnection = new OdbcConnection(connectionString);
            odbcConnection.Open();
            OdbcCommand odbcCommand = new OdbcCommand("select * from classicmodels.customers");
            odbcCommand.ExecuteReader();

            return dataTable;
        }

        public void WriteData(DataTable data, string file)
        {
            throw new NotImplementedException();
        }
    }
}
