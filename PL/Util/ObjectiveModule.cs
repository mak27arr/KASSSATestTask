using Autofac;
using KASSSATestTask.BLL.Interface;
using KASSSATestTask.BLL.Services;
using KASSSATestTask.DAL.Interface;
using KASSSATestTask.DAL.Repositories;
using KASSSATestTask.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace KASSSATestTask.PL.Util
{
    public class ObjectiveModule : Module
    {
        private string connectionString;
        public ObjectiveModule(string connection)
        {
            connectionString = connection;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var set = new DbContextOptionsBuilder<ObjectiveContext>().UseNpgsql(connectionString).Options;
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().WithParameter("options", set);
            builder.RegisterType<ObjectiveService>().As<IObjectiveService>();
        }
    }
}
