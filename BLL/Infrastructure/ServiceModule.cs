using KASSSATestTask.DAL.Interface;
using KASSSATestTask.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;

namespace KASSSATestTask.BLL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            var set = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(set);
        }
    }
}
