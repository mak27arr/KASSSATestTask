using AutoMapper;
using KASSSATestTask.BLL.Infrastructure;
using KASSSATestTask.BLL.Interface;
using KASSSATestTask.DAL.Interface;
using KASSSATestTask.Models.Entities;
using System;
using System.Collections.Generic;

namespace KASSSATestTask.BLL.Services
{
    public class ObjectiveService : IObjectiveService
    {
        IUnitOfWork Database { get; set; }
        public ObjectiveService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void AddObjective(ObjectiveDTO objectiveDto)
        {
            Objective objective = new Objective { Created = objectiveDto.Created, 
                Deadline = objectiveDto.Deadline, 
                Description = objectiveDto.Description, 
                Name = objectiveDto.Name, 
                Status = objectiveDto.Status };
            Database.Objective.Create(objective);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public ObjectiveDTO GetObjective(int? id)
        {
            if (id == null)
                throw new ValidationException("Empty id", "");
            var objective = Database.Objective.Get(id.Value);
            if (objective == null)
                throw new ValidationException("Not faund", "");
            return new ObjectiveDTO { Created = objective.Created, Deadline = objective.Deadline, Description = objective.Description, id = objective.id, Name= objective.Name, Status = objective.Status };
        }
        public IEnumerable<ObjectiveDTO> GetObjectives()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Objective, ObjectiveDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Objective>, List<ObjectiveDTO>>(Database.Objective.GetAll());
        }
        public void UpdateObjective(ObjectiveDTO orderDto)
        {
            Database.Dispose();
        }
    }
}
