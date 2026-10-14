using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Sqlite;
using NEA_Rowing_Calculation_Website.Data;
using NEA_Rowing_Calculation_Website.Model;
using NuGet.Protocol.Core.Types;

namespace NEA_Rowing_Calculation_Website
{
    public class WorkoutSession
    {
        public int WorkoutSessionID { get; set; }
        public int WorkoutID { get; set; }
        public Workout Workout { get; set; }
        public int SessionNumber { get; set; }
        public string TaskDescription { get; set; } = "";
        public DateTime PlannedDate { get; set; }

        public bool Done { get; set; }
        public DateTime? DoneDate { get; set; }

    }
}