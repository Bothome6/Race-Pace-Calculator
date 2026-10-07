using Microsoft.Data.Sqlite;

namespace NEA_Rowing_Calculation_Website.Model
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public string? PrimaryGoal { get; set; } = string.Empty;
        public string? ExperienceLevel { get; set; } = string.Empty;
        public string? SessionPerWeek { get; set; } = string.Empty;
        public string? PlanFocus { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

}