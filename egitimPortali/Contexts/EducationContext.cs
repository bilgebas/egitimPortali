using egitimPortali.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class EducationContext : DbContext
{
    public EducationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Education> Educations { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Participation> Participations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

public class ApplicationUser : IdentityUser
{
    // Additional user properties if needed
}
