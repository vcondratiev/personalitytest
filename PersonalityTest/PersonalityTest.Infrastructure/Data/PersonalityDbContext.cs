using Microsoft.EntityFrameworkCore;
using PersonalityTest.Domain.Entities;

namespace PersonalityTest.Infrastructure.Data
{
    public class PersonalityDbContext : DbContext
    {
        public PersonalityDbContext(DbContextOptions<PersonalityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Test>(e =>
            {
                e.Property(p => p.Identificator).IsRequired();
                e.Property(p => p.QuestionSetId).IsRequired();

                //e.Property(p => p.CreatedAt).HasDefaultValueSql("getdate()");
            });

            builder.Entity<TestResult>(e =>
            {
                e.Property(p => p.TestId).IsRequired();
                e.Property(p => p.Result).IsRequired();
            });

            builder.Entity<QuestionSet>(e =>
            {
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Order).IsRequired();
                e.Property(p => p.Description).IsRequired();
            });

            builder.Entity<Question>(e =>
            {
                e.Property(p => p.Title).IsRequired();
                e.Property(p => p.Order).IsRequired();
            });

            builder.Entity<QuestionOption>(e =>
            {
                e.Property(p => p.Text).IsRequired();
                e.Property(p => p.Value).IsRequired();
            });

            builder.Entity<QuestionAnswer>(e =>
            {
                e.Property(p => p.QuestionId).IsRequired();
                e.Property(p => p.TestId).IsRequired();
                e.Property(p => p.Value).IsRequired();
            });
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<QuestionSet> QuestionSets { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
