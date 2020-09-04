using AutoMapper;
using KASSSATestTask.BLL.BuisnesModule;
using KASSSATestTask.BLL.Infrastructure;
using KASSSATestTask.BLL.Interface;
using KASSSATestTask.DAL.Interface;
using KASSSATestTask.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KASSSATestTask.BLL.Services
{
    public class ObjectiveService : IObjectiveService
    {
        IUnitOfWork Database { get; set; }
        IMapper mapper;
        IMapper mapperDTO;
        public ObjectiveService(IUnitOfWork uow)
        {
            Database = uow;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<Objective, ObjectiveDTO>()).CreateMapper();
            mapperDTO = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveDTO, Objective>().ForMember(d => d.Created, (options) => options.Ignore())).CreateMapper();
        }
        public async Task<bool> AddObjectiveAsync(ObjectiveDTO objectiveDto)
        {
            Objective objective = mapperDTO.Map<ObjectiveDTO,Objective>(objectiveDto);
            // !!! Тут я не впевниний чи це правильно
            objective.Id = 0;
            //
            objective.Created = DateTime.Now;
            await Database.Objective.CreateAsync(objective);
            await Database.SaveAsync();
            return true;
        }
        public async Task<ObjectiveDTO> GetObjectiveAsync(int? id)
        {
            if (id == null || !id.HasValue)
                throw new ValidationException("Empty id", "");
            var objective = await Database.Objective.GetAsync(id.Value);
            if (objective == null)
                throw new ValidationException("Not found", "");
            StatusUpdate statusUpdate = new StatusUpdate();
            if(statusUpdate.UpdateStatus(objective))
            {
                await Database.Objective.UpdateAsync(objective);
                await Database.SaveAsync();
            }            
            return mapper.Map<Objective, ObjectiveDTO>(objective);
        }
        public async Task<IEnumerable<ObjectiveDTO>> GetObjectivesAsync()
        {
            StatusUpdate statusUpdate = new StatusUpdate();
            var objectives = await Database.Objective.GetAllAsync();
            foreach(var item in objectives)
            {
                if (statusUpdate.UpdateStatus(item))
                {
                    await Database.Objective.UpdateAsync(item);  
                }
            }
            await Database.SaveAsync();
            return mapper.Map<IEnumerable<Objective>, List<ObjectiveDTO>>(objectives);
        }
        public async Task<bool> UpdateObjectiveAsync(ObjectiveDTO objectiveDto)
        {
            if (objectiveDto == null)
                throw new ValidationException("Empty data", "");
            Objective objective = mapperDTO.Map<ObjectiveDTO,Objective>(objectiveDto);
            if (await Database.Objective.UpdateAsync(objective))
            {
                await Database.SaveAsync();
                return true;
            }
            else
            {
                throw new ValidationException("Cant update objective", "");
            }
        }
        public async Task<bool> DeleteObjectiveAsync(int? id)
        {
            if (id == null || !id.HasValue)
                throw new ValidationException("Empty id", "");
            if(await Database.Objective.DeleteAsync(id.Value))
            {
                await Database.SaveAsync();
                return true;
            }
            else
            {
                throw new ValidationException("Cant delete objective", "");
            }
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
