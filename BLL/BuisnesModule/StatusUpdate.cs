using KASSSATestTask.BLL.Infrastructure;
using KASSSATestTask.Models.Entities;
using System;

namespace KASSSATestTask.BLL.BuisnesModule
{
    public class StatusUpdate
    {
        public bool UpdateStatus(Objective objective)
        {
            if(objective==null)
                throw new ValidationException("Objective = null cant determine status", "");
            if(!objective.Created.HasValue || !objective.Deadline.HasValue)
                throw new ValidationException("Empty objective data cant determine status", "");
            if (objective.Status != ObjectiveStatus.Finish)
            {
                return false;
            }
            if (DateTime.Now.CompareTo(objective.Created.Value.Add(objective.Deadline.Value)) >= 0){
                objective.Status = ObjectiveStatus.Overdue;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
