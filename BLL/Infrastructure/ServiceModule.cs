using Autofac;
using KASSSATestTask.DAL.Interface;
using KASSSATestTask.DAL.Repositories;
using KASSSATestTask.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace KASSSATestTask.BLL.Infrastructure
{
    public class ServiceModule: Module
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var set = new DbContextOptionsBuilder<ObjectiveContext>().UseNpgsql(connectionString).Options;
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().WithParameter("options", set);
        }
    }
}
