using Microsoft.EntityFrameworkCore;
using University.Core.Entities;

namespace University.Infraestructure.Data;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=University.db",
                b => b.MigrationsAssembly("University.Infraestructure"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasIndex(s => s.Code).IsUnique();
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s => s.Code).IsRequired().HasMaxLength(20);
            entity.Property(s => s.Credits).IsRequired();
        });

        modelBuilder.Entity<StudentSubject>()
             .ToTable("StudentSubject")
            .HasKey(sc => new { sc.StudentId, sc.SubjectId });

        modelBuilder.Entity<StudentSubject>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentSubjects)
            .HasForeignKey(sc => sc.StudentId);

        modelBuilder.Entity<StudentSubject>()
            .HasOne(sc => sc.Subject)
            .WithMany(c => c.StudentSubjects)
            .HasForeignKey(sc => sc.SubjectId);
    }
}