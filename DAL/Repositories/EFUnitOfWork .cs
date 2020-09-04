using KASSSATestTask.DAL.Interface;
using KASSSATestTask.Models.EF;
using KASSSATestTask.Models.Entities;
using KASSSATestTask.Models.Interface;
using KASSSATestTask.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KASSSATestTask.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private ObjectiveContext db;
        private  IRepository<Objective> objectiveRepository;
        public EFUnitOfWork(DbContextOptions<ObjectiveContext> options)
        {
            db = new ObjectiveContext(options);
        }
        public IRepository<Objective> Objective
        {
            get
            {
                if (objectiveRepository == null)
                    objectiveRepository = new ObjectiveRepository(db);
                return objectiveRepository;
            }
        }
        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            if (!this.disposed)
            {
                if (db!=null)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
