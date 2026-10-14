using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NEA_Rowing_Calculation_Website.Components.Pages;
using NEA_Rowing_Calculation_Website.Data;
using NEA_Rowing_Calculation_Website.Model;

namespace NEA_Rowing_Calculation_Website.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
    }
    
}
