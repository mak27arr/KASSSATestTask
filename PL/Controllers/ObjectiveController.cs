using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KASSSATestTask.BLL.Interface;
using KASSSATestTask.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KASSSATestTask.PL.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ObjectiveController : ControllerBase
    {
        IObjectiveService objectiveService;
        IMapper mapper;
        public ObjectiveController(IObjectiveService serv)
        {
            objectiveService = serv;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectiveDTO, ObjectiveViewModel>()).CreateMapper();
        }
        /// <summary>
        /// Get all objectives 
        /// </summary>
        /// <returns></returns>
        // GET: api/Objective
        [HttpGet]
        public async Task<IEnumerable<ObjectiveViewModel>> GetAsync()
        {
            IEnumerable<ObjectiveDTO> objectiveDtos = await objectiveService.GetObjectivesAsync();
            var objectives = mapper.Map<IEnumerable<ObjectiveDTO>, List<ObjectiveViewModel>>(objectiveDtos);
            return objectives;
        }
        /// <summary>
        /// Get objective by id
        /// </summary>
        /// <param name="id">objective id</param>
        /// <returns></returns>
        // GET: api/Objective/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ObjectiveViewModel> GetAsync(int id)
        {
            ObjectiveDTO objectiveDto = await objectiveService.GetObjectiveAsync(id);
            var objective = mapper.Map<ObjectiveDTO, ObjectiveViewModel>(objectiveDto);
            return objective;
        }
        /// <summary>
        /// Add objective
        /// </summary>
        /// <param name="value">objective item</param>
        // POST: api/Objective
        [HttpPost]
        public async void PostAsync([FromBody] ObjectiveViewModel value)
        {
            var objective = mapper.Map<ObjectiveViewModel,ObjectiveDTO>(value);
            await objectiveService.AddObjectiveAsync(objective);
        }
        /// <summary>
        /// Update objective
        /// </summary>
        /// <param name="value"></param>
        // PUT: api/Objective/5
        [HttpPut]
        public async void PutAsync([FromBody] ObjectiveViewModel value)
        {
            var objective = mapper.Map<ObjectiveViewModel, ObjectiveDTO>(value);
            await objectiveService.UpdateObjectiveAsync(objective);
        }
        /// <summary>
        /// Delete objective by id
        /// </summary>
        /// <param name="id">objective id</param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void DeleteAsync(int id)
        {
            await objectiveService.DeleteObjectiveAsync(id);
        }
    }
}
