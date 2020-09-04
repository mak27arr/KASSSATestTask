using KASSSATestTask.Models.EF;
using KASSSATestTask.Models.Entities;
using KASSSATestTask.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KASSSATestTask.Models.Repositories
{
    public class ObjectiveRepository : IRepository<Objective>
    {
        private ObjectiveContext db;
        public ObjectiveRepository(ObjectiveContext context)
        {
            this.db = context;
        }
        public async Task<bool> CreateAsync(Objective item)
        {
            await db.Objectives.AddAsync(item);
            return true;
        }
        public async Task<bool> UpdateAsync(Objective item)
        {
            Objective objective = await db.Objectives.FindAsync(item);
            if (objective != null) { 
                db.Entry(item).State = EntityState.Modified;
                db.Entry(item).Property(x => x.Created).IsModified = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            Objective objective = await db.Objectives.FindAsync(id);
            if (objective != null)
            {
                db.Objectives.Remove(objective);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Objective> GetAsync(int id)
        {
            return await db.Objectives.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<IEnumerable<Objective>> GetAllAsync()
        {
            return await db.Objectives.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Objective>> FindAsync(Func<Objective, bool> predicate)
        {
            return await db.Objectives.AsNoTracking().Where(predicate).AsQueryable().ToListAsync();
        }

    }
}
