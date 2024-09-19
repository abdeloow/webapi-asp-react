using Microsoft.EntityFrameworkCore;

namespace QuizzFullStack;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuizSubmission> QuizSubmissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Questions)
            .WithOne(q => q.Quiz)
            .HasForeignKey(q => q.QuizId);

        modelBuilder.Entity<QuizSubmission>()
            .HasOne(qs => qs.User)
            .WithMany()
            .HasForeignKey(qs => qs.UserId);

        modelBuilder.Entity<QuizSubmission>()
            .HasOne(qs => qs.Quiz)
            .WithMany()
            .HasForeignKey(qs => qs.QuizId);

        // Additional configurations can be added here
    }
}