using AutoMapper;
using KASSSATestTask.BLL.BuisnesModule;
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveDTO,Objective>().ForMember(d => d.Id, (options) => options.Ignore())).CreateMapper();
            Objective objective = mapper.Map<ObjectiveDTO,Objective>(objectiveDto);
            objective.Created = DateTime.Now;
            Database.Objective.Create(objective);
            Database.Save();
        }
        public ObjectiveDTO GetObjective(int? id)
        {
            if (id == null || !id.HasValue)
                throw new ValidationException("Empty id", "");
            var objective = Database.Objective.Get(id.Value);
            if (objective == null)
                throw new ValidationException("Not found", "");
            StatusUpdate statusUpdate = new StatusUpdate();
            if(statusUpdate.UpdateStatus(objective))
            {
                Database.Objective.Update(objective);
                Database.Save();
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Objective, ObjectiveDTO>()).CreateMapper();
            return mapper.Map<Objective, ObjectiveDTO>(objective);
        }
        public IEnumerable<ObjectiveDTO> GetObjectives()
        {
            StatusUpdate statusUpdate = new StatusUpdate();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Objective, ObjectiveDTO>()).CreateMapper();
            var objectives = Database.Objective.GetAll();
            foreach(var item in objectives)
            {
                if (statusUpdate.UpdateStatus(item))
                {
                    Database.Objective.Update(item);  
                }
            }
            Database.Save();
            return mapper.Map<IEnumerable<Objective>, List<ObjectiveDTO>>(objectives);
        }
        public void UpdateObjective(ObjectiveDTO objectiveDto)
        {
            if (objectiveDto == null)
                throw new ValidationException("Empty data", "");
            var objOld = Database.Objective.Get(objectiveDto.id);
            if (objOld == null)
                throw new ValidationException("Item not found, cant update", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveDTO,Objective>().ForMember(d => d.Created, (options) => options.Ignore())).CreateMapper();
            Objective objective = mapper.Map<ObjectiveDTO,Objective>(objectiveDto);
            Database.Objective.Update(objective);
            Database.Save();
        }
        public void DeleteObjective(int? id)
        {
            if (id == null || !id.HasValue)
                throw new ValidationException("Empty id", "");
            var objective = Database.Objective.Get(id.Value);
            if (objective == null)
                throw new ValidationException("Not found", "");
            Database.Objective.Delete(id.Value);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
