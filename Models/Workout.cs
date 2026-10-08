using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Sqlite;
using NEA_Rowing_Calculation_Website.Data;

namespace NEA_Rowing_Calculation_Website.Model
{
    public class Workout
    {
        [Key]
        public int WorkoutID { get; set; }
        [Required]
        public string? UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; } 
        public string? PrimaryGoal { get; set; } = string.Empty;
        public string? ExperienceLevel { get; set; } = string.Empty;
        public string? SessionPerWeek { get; set; } = string.Empty;        
        public string? PlanFocus { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;


    }

}