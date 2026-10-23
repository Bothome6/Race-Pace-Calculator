using System.Collections;
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

        public string[] WorkoutInformation => (ExperienceLevel, PrimaryGoal, PlanFocus) switch
        {
            ("Beginner", "Fat Loss", "Technique") => new[]
            {
                "20 min steady, change drill (arms only, arms and body, full slide) every 4 min, 18 spm",
                "25 min easy, 1 min pause drill then 3 min rowing, repeat, 18-20 spm",
                "20 min steady, focus on legs-first sequencing, 20 spm",
                "5 x 4 min steady with 1 min rest, one technique cue per piece, 20 spm",
                "25 min steady, square-blade drill every 5 min, 18-20 spm",
                "20 min steady with 10 slow-slide strokes every minute, 18 spm",
            },

            ("Beginner", "Fat Loss", "Power") => new[]
            {
                "20 min steady, 10 power strokes every 3 min, 20 spm",
                "6 x 3 min steady with 1 min rest, last 10 strokes firm in each piece, 20 spm",
                "25 min steady, 5 hard strokes every minute, 20 spm",
                "20 min alternating 2 min firm pressure at 18 spm and 2 min easy at 20 spm",
                "6 x 1 min firm with 2 min easy, 22 spm",
                "25 min steady, 10 power strokes at the start of every 5 min block, 20 spm"
            },

            ("Beginner", "Fat Loss", "Cardio") => new[]
            {
                "30 min steady, 20 spm",
                "3 x 10 min steady with 2 min rest, 20 spm",
                "30 min steady, 1 min slightly harder every 5 min, 20-22 spm",
                "5 x 6 min steady with 1 min rest, 20 spm",
                "35 min easy steady, 18-20 spm",
                "20 min steady, then 5 min at 22 spm, then 5 min easy"
            },

            ("Beginner", "Endurance", "Technique") => new[]
            {
                "30 min steady, drills in first 5 min and last 5 min, 18-20 spm",
                "25 min steady, 10 pause-at-finish strokes every 3 min, 18-20 spm",
                "30 min steady, change one technique focus every 5 min, 18-20 spm",
                "4 x 8 min steady with 1 min rest, one drill per piece, 20 spm",
                "35 min steady, ratio focus (drive 1 : recovery 2), 18 spm",
                "30 min steady with 10 arms-only strokes every 5 min, 20 spm"
            },

            ("Beginner", "Endurance", "Power")=> new[]
            {
                "30 min steady, 10 power strokes every 4 min, 20 spm",
                "4 x 8 min steady with 2 min rest, 10 firm strokes at the start of each piece, 20 spm",
                "30 min steady, 2 min low rate firm pressure every 10 min, 18 spm",
                "35 min steady, 5 firm strokes every minute, 20 spm",
                "3 x 10 min with 2 min rest, last 2 min of each piece firm, 20-22 spm",
                "30 min steady, 20 power strokes at the 10 min and 20 min marks, 20 spm"
            },

            ("Beginner", "Endurance", "Cardio") => new[]
            {
                "35 min steady, 20 spm",
                "40 min easy steady, 18-20 spm",
                "3 x 12 min steady with 2 min rest, 20 spm",
                "30 min steady, 22 spm for the last 5 min",
                "2 x 20 min steady with 3 min rest, 20 spm",
                "45 min easy steady, 18 spm"
            },

            ("Beginner", "2k Test", "Technique") => new[]
            {
                "4 x 500m with 2 min rest, focus on a clean catch, 22 spm",
                "3 x 750m with 3 min rest, controlled slide, 22 spm",
                "8 x 250m with 90 sec rest, relaxed recovery, 24 spm",
                "2 x 1000m with 4 min rest, even splits, 22 spm",
                "6 x 500m with 2 min rest, one technique cue per piece, 22 spm",
                "15 min steady with drills, then 2 x 500m with 3 min rest, 22 spm"
            },

            ("Beginner", "2k Test", "Power") => new[]
            {
                "8 x 250m with 2 min rest, firm drive, 24 spm",
                "5 x 500m with 2 min rest, strong first 10 strokes, 24 spm",
                "4 x 500m with 3 min rest, 24 spm",
                "6 x 1 min hard with 2 min rest, 26 spm",
                "10 min steady, then 4 x 250m with 2 min rest, 26 spm",
                "2 x 500m and 2 x 250m with 2 min rest between, 24 spm"
            },

            ("Beginner", "2k Test", "Cardio") => new[]
            {
                "2 x 1000m with 4 min rest, 22 spm",
                "4 x 750m with 3 min rest, 22 spm",
                "5 x 4 min steady with 2 min rest, 22 spm",
                "3 x 8 min steady with 3 min rest, 22 spm",
                "4 x 1000m with 4 min rest, 20 spm",
                "20 min steady, then 1 x 1000m at 2k split +10s, 22 spm"
            },

            ("Intermediate", "Fat Loss", "Technique") => new[]
            {
                "35 min steady, pause drill every 5 min, 20 spm",
                "30 min steady, rate ladder 18-22 spm changing every 5 min",
                "30 min steady, 10 strokes of arms-body-slide drill every 3 min, 20 spm",
                "40 min steady, focus on a consistent split, 20 spm",
                "6 x 5 min steady with 1 min rest, one technique cue per piece, 20 spm",
                "30 min alternating 3 min drills and 3 min normal rowing, 18-20 spm"
            },

            ("Intermediate", "Fat Loss", "Power") => new[]
            {
                "10 x 1 min hard, 1 min easy, 22 spm",
                "35 min steady, 10 power strokes every 2 min, 20 spm",
                "6 x 3 min firm with 1 min rest, 24 spm",
                "30 min steady, 20 power strokes every 5 min, 20 spm",
                "5 x 4 min with 2 min rest, last minute hard, 22 spm",
                "12 x 30 sec hard, 1 min easy, 24 spm"
            },

            ("Intermediate", "Fat Loss", "Cardio") => new[]
            {
                "45 min steady, 20 spm",
                "3 x 15 min steady with 2 min rest, 20 spm",
                "40 min steady, 1 min harder every 5 min, 22 spm",
                "30 min steady then 10 min easy, 20 spm",
                "5 x 8 min steady with 1 min rest, 20-22 spm",
                "50 min easy steady, 18-20 spm"
            },

            ("Intermediate", "Edurance", "Technique") => new[]
            {
                "45 min steady, drill block every 10 min, 18-20 spm",
                "40 min steady, ratio focus (drive 1 : recovery 2), 18 spm",
                "40 min steady with rate ladder every 10 min, 18-22 spm",
                "4 x 10 min steady with 2 min rest, one drill per piece, 20 spm",
                "50 min steady, check sequencing every 5 min, 20 spm",
                "45 min steady, 10 pause strokes every 5 min, 18-20 spm"
            },

            ("Intermediate", "Edurance", "Power") => new[]
            {
                "4 x 10 min low rate, high resistance with 2 min rest, 18 spm",
                "45 min steady, 20 power strokes every 10 min, 20 spm",
                "5 x 8 min with 2 min rest, last 2 min firm, 20-22 spm",
                "3 x 15 min steady with 3 min rest, 10 firm strokes every 3 min, 20 spm",
                "40 min steady, 2 min low rate firm pressure every 8 min, 18 spm",
                "6 x 6 min low rate, high resistance with 90 sec rest, 18 spm"
            },

            ("Intermediate", "Edurance", "Cardio") => new[]
            {
                "60 min steady, 20 spm",
                "3 x 20 min steady with 3 min rest, 20 spm",
                "50 min steady, 22 spm for the last 10 min",
                "4 x 15 min steady with 2 min rest, 20 spm",
                "55 min easy steady, 18-20 spm",
                "40 min steady, then 10 min at 22 spm"
            },

            ("Intermediate", "2k Test", "Technique") => new[]
            {
                "4 x 750m at 2k split +5s with 3 min rest, 24 spm",
                "8 x 250m at 2k split +3s with 90 sec rest, 28 spm",
                "3 x 1000m at 2k split +6s with 4 min rest, 24 spm",
                "5 x 500m at 2k split +3s with 2 min rest, 26 spm",
                "2 x 1500m at 2k split +8s with 5 min rest, 24 spm",
                "10 min steady with drills, then 4 x 500m at 2k split +4s with 2 min rest, 26 spm"
            },

            ("Intermediate", "2k Test", "Power") => new[]
            {
                "10 x 250m at 2k split -2s with 90 sec rest, 30 spm",
                "6 x 250m at 2k split -3s with 2 min rest, 32 spm",
                "5 x 500m at 2k split with 3 min rest, 28 spm",
                "8 x 1 min at 2k split with 1 min rest, 30 spm",
                "4 x 500m at 2k split -1s with 3 min rest, 28 spm",
                "12 x 30 sec at 2k split -2s with 90 sec rest, 32 spm"
            },

            ("Intermediate", "2k Test", "Cardio") => new[]
            {
                "3 x 1500m at 2k split +8s with 4 min rest, 22 spm",
                "5 x 4 min at 2k split +10s with 2 min rest, 22-24 spm",
                "4 x 750m at 2k split +6s with 3 min rest, 24 spm",
                "2 x 2000m at 2k split +10s with 5 min rest, 22 spm",
                "5 x 1000m at 2k split +8s with 3 min rest, 24 spm",
                "20 min steady, then 3 x 500m at 2k split +4s with 2 min rest, 24 spm"
            },

            ("Experienced", "Fat Loss", "Technique") => new[]
            {
                "50 min steady, pause drill every 5 min, 20 spm",
                "45 min steady, 10 strokes of drill every 3 min, 20 spm",
                "60 min steady, rate ladder 18-22 spm changing every 10 min",
                "45 min steady, ratio focus at 18 spm for 15 min then 20 spm",
                "8 x 6 min steady with 1 min rest, one drill per piece, 20 spm",
                "50 min alternating 5 min drills and 5 min normal rowing, 18-22 spm"
            },

            ("Experienced", "Fat Loss", "Power") => new[]
            {
                "12 x 1 min at 2k split / 1 min easy, 28 spm",
                "50 min steady, 20 power strokes every 5 min, 20 spm",
                "8 x 2 min hard with 1 min easy, 26 spm",
                "6 x 4 min hard with 2 min easy, 26 spm",
                "16 x 30 sec hard / 30 sec easy, 30 spm",
                "45 min steady with 10 hard strokes every 2 min, 22 spm"
            },

            ("Experienced", "Fat Loss", "Cardio") => new[]
            {
                "75 min steady, 18-20 spm",
                "4 x 15 min steady with 2 min rest, 20 spm",
                "60 min steady, 1 min harder every 5 min, 22 spm",
                "90 min easy steady, 18 spm",
                "3 x 25 min steady with 3 min rest, 20 spm",
                "60 min steady, last 15 min at 22 spm"
            },

            ("Experienced", "Endurance", "Technique") => new[]
            {
                "75 min steady, drill block every 15 min, 18-20 spm",
                "60 min steady with rate ladder every 10 min, 18-22 spm",
                "70 min steady, ratio focus (drive 1 : recovery 2), 18 spm",
                "5 x 12 min steady with 2 min rest, one drill per piece, 20 spm",
                "60 min steady, 10 pause strokes every 5 min, 20 spm",
                "75 min steady, change technique focus every 15 min, 18-20 spm"
            },

            ("Experienced", "Endurance", "Power") => new[]
            {
                "5 x 10 min low rate, high resistance with 2 min rest, 18 spm",
                "60 min steady, 20 power strokes every 10 min, 20 spm",
                "4 x 15 min with 3 min rest, last 3 min firm, 20-22 spm",
                "8 x 6 min low rate, high resistance with 90 sec rest, 18 spm",
                "75 min steady, 2 min low rate firm pressure every 10 min, 18 spm",
                "3 x 20 min steady with 3 min rest, 10 firm strokes every 2 min, 20 spm"
            },

            ("Experienced", "Endurance", "Cardio") => new[]
            {
                "90 min steady, 18-20 spm",
                "4 x 20 min steady with 3 min rest, 20 spm",
                "75 min steady, last 15 min at 22 spm",
                "60 min steady, 20 spm",
                "2 x 40 min steady with 5 min rest, 18-20 spm",
                "80 min easy steady, 18 spm"
            },

            ("Experienced", "2k Test", "Technique") => new[]
            {
                "6 x 500m at 2k split +2s with 2 min rest, 30 spm",
                "4 x 750m at 2k split +3s with 3 min rest, 28 spm",
                "10 x 250m at 2k split +1s with 60 sec rest, 34 spm",
                "3 x 1000m at 2k split +4s with 4 min rest, 28 spm",
                "5 x 500m at 2k split +1s with 3 min rest, 32 spm",
                "15 min steady with drills, then 6 x 500m at 2k split +2s with 2 min rest, 30 spm"
            },

            ("Experienced", "2k Test", "Power") => new[]
            {
                "12 x 250m at 2k split -3s with 90 sec rest, 34 spm",
                "8 x 250m at 2k split -4s with 2 min rest, 36 spm",
                "6 x 500m at 2k split -1s with 3 min rest, 32 spm",
                "10 x 1 min at 2k split with 1 min rest, 34 spm",
                "4 x 500m at 2k split -2s with 3 min rest, 32 spm",
                "16 x 30 sec at 2k split -3s with 90 sec rest, 36 spm"
            },

            ("Experienced", "2k Test", "Cardio") => new[]
            {
                "4 x 1500m at 2k split +6s with 4 min rest, 24 spm",
                "6 x 1000m at 2k split +5s with 3 min rest, 26 spm",
                "3 x 2000m at 2k split +8s with 5 min rest, 24 spm",
                "8 x 750m at 2k split +4s with 2 min rest, 28 spm",
                "30 min steady, then 4 x 500m at 2k split +2s with 2 min rest, 28 spm",
                "6 x 4 min at 2k split +8s with 2 min rest, 26 spm"
            },
            _ => Array.Empty<string>()
        };
    }

}