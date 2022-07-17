using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DataObjects; 
namespace DataHelper
{   
    public class CustomerAPIDataHelper : ICustomerAPIHelper
    {
        IRestAPIHelper _restAPIHelper; 
        public CustomerAPIDataHelper(IRestAPIHelper restAPIHelper)
        {
            _restAPIHelper = restAPIHelper; 
        }

        public List<Customer> GetCustomers(Dictionary<string, string> parameters)
        {
            List<Customer> customers = new List<Customer>();
            Customer customer;

            JObject content = JObject.Parse(_restAPIHelper.GetData(parameters));

            var errors = new List<string>();
            foreach (var fregment in content)
            {
                customer = JsonConvert.DeserializeObject<Customer>(fregment.Value.ToString(), new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
                    {
                        errors.Add(earg.ErrorContext.Member.ToString());
                        earg.ErrorContext.Handled = true;
                    }
                });

                customer.customerid = fregment.Key.ToString();
                customers.Add(customer);
            }
            return customers;
        }
    }
}
