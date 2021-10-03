using Gymate.Infrastructure.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gymate.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Exercise> Exercises{ get; set; }
        public DbSet<Routine> Routines{ get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<ExerciseRoutine> ExerciseRoutine { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ExerciseRoutine>()
                .HasKey(er => new { er.ExerciseId, er.RoutineId });

            builder.Entity<ExerciseRoutine>()
                .HasOne<Exercise>(er => er.Exercise)
                .WithMany(e => e.ExerciseRoutines)
                .HasForeignKey(er => er.ExerciseId);


            builder.Entity<ExerciseRoutine>()
                .HasOne<Routine>(er => er.Routine)
                .WithMany(r => r.ExerciseRoutines)
                .HasForeignKey(er => er.RoutineId);
        }
    }
}
