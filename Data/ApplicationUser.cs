using Microsoft.AspNetCore.Identity;
using NEA_Rowing_Calculation_Website.Model;

namespace NEA_Rowing_Calculation_Website.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
