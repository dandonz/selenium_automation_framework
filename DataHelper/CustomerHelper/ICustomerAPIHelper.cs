using System.Collections.Generic;
using DataObjects; 
namespace DataHelper
{
    public interface ICustomerAPIHelper
    {
        List<Customer> GetCustomers(Dictionary<string, string> parameters);
    }
}
