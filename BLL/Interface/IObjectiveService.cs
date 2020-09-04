using KASSSATestTask.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KASSSATestTask.BLL.Interface
{
    public interface IObjectiveService
    {
        Task<ObjectiveDTO> GetObjectiveAsync(int? id);
        Task<IEnumerable<ObjectiveDTO>> GetObjectivesAsync();
        Task<bool> AddObjectiveAsync(ObjectiveDTO orderDto);
        Task<bool> UpdateObjectiveAsync(ObjectiveDTO orderDto);
        Task<bool> DeleteObjectiveAsync(int? id);
        void Dispose();
    }
}
