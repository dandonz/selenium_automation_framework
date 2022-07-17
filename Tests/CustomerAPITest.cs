using NUnit.Framework;
using DataHelper;
using Utilities; 
using System.Collections.Generic;
using Autofac; 

namespace danyspace.Tests
{
    public class CustomerAPITest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GetAllCustomersFromRestAPITest()
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ICustomerAPIDataHelperApplication>();
                app.Run();
            }
        }
    }
}
