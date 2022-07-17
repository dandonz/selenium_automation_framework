using Autofac;
using DataHelper;

namespace DataHelper
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AssignmentAPIApplication>().As<IAssignmentAPIApplication>();
            builder.RegisterType<CustomerAPIDataHelperApplication>().As<ICustomerAPIDataHelperApplication>();
            builder.RegisterType<AssignmentAPIHelper>().As<IAssignmentAPIHelper>();
            builder.RegisterType<AssignmentExcelHelper>().As<IAssignmentExcelHelper>();
            builder.RegisterType<CustomerAPIDataHelper>().As<ICustomerAPIHelper>();
            builder.RegisterType<ExcelDataHelper>().As<IExcelDataHelper>();
            builder.RegisterType<RestApiHelper>().As<IRestAPIHelper>();
            builder.RegisterType<SQLHelper>().As<ISQLHelper>();
            builder.RegisterType<MySQLHelper>().As<IMySQLHelper>();
            builder.RegisterType<TextFileHelper>().As<ITextFileHelper>();

            return builder.Build();
        }
    }
}
