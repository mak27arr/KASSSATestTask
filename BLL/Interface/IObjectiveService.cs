using KASSSATestTask.Models.Entities;
using System.Collections.Generic;

namespace KASSSATestTask.BLL.Interface
{
    public interface IObjectiveService
    {
        ObjectiveDTO GetObjective(int? id);
        IEnumerable<ObjectiveDTO> GetObjectives();
        void AddObjective(ObjectiveDTO orderDto);
        void UpdateObjective(ObjectiveDTO orderDto);
        void DeleteObjective(int? id);
        void Dispose();
    }
}
