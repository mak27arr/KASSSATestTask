using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KASSSATestTask.Models.Entities
{
    public class Objective
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? Deadline { get; set; }
        public ObjectiveStatus? Status { get; set; }
    }
}
