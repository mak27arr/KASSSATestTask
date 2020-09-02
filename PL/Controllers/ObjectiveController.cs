using System.Collections.Generic;
using AutoMapper;
using KASSSATestTask.BLL.Interface;
using KASSSATestTask.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KASSSATestTask.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        IObjectiveService objectiveService;
        public ObjectiveController(IObjectiveService serv)
        {
            objectiveService = serv;
        }
        // GET: api/Objective
        [HttpGet]
        public IEnumerable<ObjectiveViewModel> Get()
        {
            IEnumerable<ObjectiveDTO> objectiveDtos = objectiveService.GetObjectives();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveDTO, ObjectiveViewModel>()).CreateMapper();
            var objectives = mapper.Map<IEnumerable<ObjectiveDTO>, List<ObjectiveViewModel>>(objectiveDtos);
            return objectives;
        }

        // GET: api/Objective/5
        [HttpGet("{id}", Name = "Get")]
        public ObjectiveViewModel Get(int id)
        {
            ObjectiveDTO objectiveDto = objectiveService.GetObjective(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveDTO, ObjectiveViewModel>()).CreateMapper();
            var objective = mapper.Map<ObjectiveDTO, ObjectiveViewModel>(objectiveDto);
            return objective;
        }

        // POST: api/Objective
        [HttpPost]
        public void Post([FromBody] ObjectiveViewModel value)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveViewModel, ObjectiveDTO>()).CreateMapper();
            var objective = mapper.Map<ObjectiveViewModel,ObjectiveDTO>(value);
            objectiveService.AddObjective(objective);
        }

        // PUT: api/Objective/5
        [HttpPut]
        public void Put([FromBody] ObjectiveViewModel value)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveViewModel, ObjectiveDTO>()).CreateMapper();
            var objective = mapper.Map<ObjectiveViewModel, ObjectiveDTO>(value);
            objectiveService.UpdateObjective(objective);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objectiveService.DeleteObjective(id);
        }
    }
}
