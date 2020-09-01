using KASSSATestTask.DAL.Interface;
using KASSSATestTask.Models.EF;
using KASSSATestTask.Models.Entities;
using KASSSATestTask.Models.Interface;
using KASSSATestTask.Models.Repositories;
using Microsoft.EntityFrameworkCore;

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
        public void Save()
        {
            db.SaveChanges();
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
