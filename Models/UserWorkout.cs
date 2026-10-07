using Microsoft.Data.Sqlite;
using NEA_Rowing_Calculation_Website.Data;

namespace NEA_Rowing_Calculation_Website.Model
{
    public class UserWorkout : ApplicationUser
    {
        public int UserID { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;

    }
}