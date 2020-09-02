using KASSSATestTask.Models.EF;
using KASSSATestTask.Models.Entities;
using KASSSATestTask.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KASSSATestTask.Models.Repositories
{
    public class ObjectiveRepository : IRepository<Objective>
    {
        private ObjectiveContext db;
        public ObjectiveRepository(ObjectiveContext context)
        {
            this.db = context;
        }
        public void Create(Objective item)
        {
            db.Objectives.Add(item);
        }
        public void Update(Objective item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Objective objective = db.Objectives.Find(id);
            if (objective != null)
                db.Objectives.Remove(objective);
        }
        public Objective Get(int id)
        {
            return db.Objectives.Find(id);
        }
        public IEnumerable<Objective> GetAll()
        {
            return db.Objectives.ToList();
        }
        public IEnumerable<Objective> Find(System.Func<Objective, bool> predicate)
        {
            return db.Objectives.Where(predicate).ToList();
        }

    }
}
