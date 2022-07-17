using System;
using DataObjects; 
namespace DataHelper
{
    public class ResourceHelper
    {
        public static T GetResource<T>() where T : class
        {
            var resource = (T)Activator.CreateInstance(typeof(T));
            return resource;
        }
        public Customer Customer => GetResource<Customer>();
        public Assignment Assignment => GetResource<Assignment>();
        public Cleaner Cleaner => GetResource<Cleaner>();
    }
}