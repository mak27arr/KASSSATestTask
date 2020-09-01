using KASSSATestTask.Models.Entities;
using System.Collections.Generic;

namespace KASSSATestTask.BLL.Interface
{
    interface IObjectiveService
    {
        void AddObjective(ObjectiveDTO orderDto);
        void UpdateObjective(ObjectiveDTO orderDto);
        ObjectiveDTO GetObjective(int? id);
        IEnumerable<ObjectiveDTO> GetObjectives();
        void Dispose();
    }
}
