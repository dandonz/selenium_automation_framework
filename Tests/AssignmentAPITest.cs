using NUnit.Framework;
using DataHelper;
using Autofac; 

namespace Tests
{
    public class AssignmentAPITest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllAssignmentsFromRestAPITest()
        {
            var container = ContainerConfig.Configure();
            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IAssignmentAPIApplication>();
                app.Run(); 
            }
        }
    }
}
