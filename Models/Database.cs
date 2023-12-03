using Microsoft.EntityFrameworkCore;

namespace Assignment_Web_APIs.Models
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubjectAssignment> StudentSubjectAssignments { get; set; }
        public DbSet<Marks> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure StudentSubjectAssignment composite key
            modelBuilder.Entity<StudentSubjectAssignment>()
                .HasKey(ssa => new { ssa.StudentId, ssa.SubjectId });

            // Define relationships between entities
            modelBuilder.Entity<StudentSubjectAssignment>()
                .HasOne(ssa => ssa.Student)
                .WithMany(s => s!.Assignments) // Adjust the property name as needed
                .HasForeignKey(ssa => ssa.StudentId);

            modelBuilder.Entity<StudentSubjectAssignment>()
                .HasOne(ssa => ssa.Subject)
                .WithMany(s => s!.Assignments) // Adjust the property name as needed
                .HasForeignKey(ssa => ssa.SubjectId);

            // Additional configurations as needed

            // Example: Configure the Marks entity
            modelBuilder.Entity<Marks>()
       .HasKey(m => m.MarksId);

            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Student)
                .WithMany(s => s!.Marks)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Marks>()
                .HasOne(m => m.Subject)
                .WithMany(s => s!.Marks)
                .HasForeignKey(m => m.SubjectId);
        }
    }
}
