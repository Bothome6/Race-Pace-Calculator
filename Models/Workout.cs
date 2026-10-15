using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NEA_Rowing_Calculation_Website.Data;

namespace NEA_Rowing_Calculation_Website.Model
{
    public class Workout
    {
        [Key]
        public int WorkoutID { get; set; }
        public string? UserID { get; set; } = "";

        public ApplicationUser User { get; set; } = null!;
        public string? PrimaryGoal { get; set; } = string.Empty;
        public string? ExperienceLevel { get; set; } = string.Empty;
        public string? SessionPerWeek { get; set; } = string.Empty;
        public string? PlanFocus { get; set; } = string.Empty;
        public string? TwoKSplit { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool Abandoned { get; set; }
        public ICollection<WorkoutSession> Sessions { get; set; }
        = new List<WorkoutSession>();

        public string WorkoutInformation => (ExperienceLevel, PrimaryGoal, PlanFocus) switch
        {
            ("Beginner", "Fat Loss", "Technique") => "20 min with drill pyramid, 18-20 spm",
            ("Beginner", "Fat Loss", "Power") => "20 min steady, 10 power strokes every 2 min, 20 spm",
            ("Beginner", "Fat Loss", "Cardio") => "25 min steady, 20 spm",
            ("Beginner", "Endurance", "Technique") => "25 min steady, drills in first 5 min, 18-20 spm",
            ("Beginner", "Endurance", "Power") => "25 min steady, 10 power strokes every 3 min, 20 spm",
            ("Beginner", "Endurance", "Cardio") => "30 min steady, 20 spm",
            ("Beginner", "2kTest", "Technique") => "5x500m with 2 min rest, 22 spm",
            ("Beginner", "2kTest", "Power") => "6x250m with 90 sec rest, 24 spm",
            ("Beginner", "2kTest", "Cardio") => "3 × 1000m with 3 min rest, 20 spm",
            ("Intermediate", "Fat Loss", "Technique") => "30 min steady with pause drills, 20 spm",
            ("Intermediate", "Fat Loss", "Power") => "8x 1 min hard, 1 min easy, 20 spm",
            ("Intermediate", "Fat Loss", "Cardio") => "8x 1 min hard, 1 min easy, 20 spm",
            ("Intermediate", "Endurance", "Technique") => "40 min steady with rate ladder, 18-20 spm",
            ("Intermediate", "Endurance", "Power") => "5 × 6 min low rate, high resistance with 2 min rest, 20 spm",
            ("Intermediate", "Endurance", "Cardio") => "50 min steady, 20 spm",
            ("Intermediate", "2kTest", "Technique") => "6 × 500m at 2k split +4s with 90 rest, 26 spm",
            ("Intermediate", "2kTest", "Power") => "8 × 250m at 2k split −2s with 90 sec rest, 30 spm",
            ("Intermediate", "2kTest", "Cardio") => "4 × 1000m at 2k split +6s with 4 min rest, 24 spm",
            ("Experienced", "Fat Loss", "Technique") => "45 min steady with rate-pyramid drills, 18-22",
            ("Experienced", "Fat Loss", "Power") => "10 × 1 min at 2k split / 1 min easy, 28 spm",
            ("Experienced", "Fat Loss", "Cardio") => "60 min steady, 20 spm",
            ("Experienced", "Endurance", "Technique") => "60 min steady, drill block every 10 min, 20 spm",
            ("Experienced", "Endurance", "Power") => "6 × 8 min low rate with 2 min rest, high resistance, 18 spm",
            ("Experienced", "Endurance", "Cardio") => "75 min steady, 18-20 spm",
            ("Experienced", "2kTest", "Technique") => "8 × 500m at 2k split +2s with 90 sec rest, 32 spm",
            ("Experienced", "2kTest", "Power") => "10 × 250m at 2k split −3s with 2 min rest, 32 spm",
            ("Experienced", "2kTest", "Cardio") => "5 × 1000m at 2k split +4s with 3 min rest, 26 spm"
        };
    }

}