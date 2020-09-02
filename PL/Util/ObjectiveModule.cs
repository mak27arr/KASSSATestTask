using KASSSATestTask.BLL.Interface;
using KASSSATestTask.BLL.Services;
using Microsoft.EntityFrameworkCore.Query;
using Ninject.Modules;

namespace KASSSATestTask.PL.Util
{
    public class ObjectiveModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IObjectiveService>().To<ObjectiveService>();
        }
    }
}
