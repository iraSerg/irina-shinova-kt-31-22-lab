using ShinovaIrinaKt_31_22.Database.Configurations;
using ShinovaIrinaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
namespace ShinovaIrinaKt_31_22.Database
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LoadConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {

        }
    }
}
