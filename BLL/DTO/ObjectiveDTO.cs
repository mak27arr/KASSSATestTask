using System;

namespace KASSSATestTask.Models.Entities
{
    public class ObjectiveDTO
    {
        public int id { get; set; }
        public DateTime? Created { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? Deadline { get; set; }
        public ObjectiveStatus? Status { get; set; }
    }
}
