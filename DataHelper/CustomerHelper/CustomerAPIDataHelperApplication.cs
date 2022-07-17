using System.Collections.Generic;
using Utilities; 
namespace DataHelper
{
    public class CustomerAPIDataHelperApplication: ICustomerAPIDataHelperApplication
    {
        ICustomerAPIHelper _customerAPIHelper;
        public CustomerAPIDataHelperApplication(ICustomerAPIHelper customerAPIHelper)
        {
            _customerAPIHelper = customerAPIHelper; 
        }
        public void Run()
        {
            string baseurl = "https://danyspace-8aeea.firebaseio.com/";
            string request = "/customers.json";
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add(API_PARAMETER.API_BASE_URL, baseurl);
            pairs.Add(API_PARAMETER.API_REQUEST, request);

            _customerAPIHelper.GetCustomers(pairs);
        }
    }
}
