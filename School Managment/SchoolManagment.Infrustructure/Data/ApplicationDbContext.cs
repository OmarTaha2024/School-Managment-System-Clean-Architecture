using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Infrustructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubject { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubject { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Ins_Subject> Ins_Subject { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<DepartmetSubject>()
                .HasKey(e => new { e.SubID, e.DID });
            modelBuilder.Entity<Ins_Subject>()
                .HasKey(e => new { e.SubId, e.InsId });
            modelBuilder.Entity<StudentSubject>()
                .HasKey(e => new { e.SubID, e.StudID });
            modelBuilder.Entity<Instructor>()
                .HasOne(e => e.Supervisor)
                .WithMany(x => x.Instructors)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
