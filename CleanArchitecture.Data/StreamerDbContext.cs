using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Data
{
    public class StreamerDbContext : DbContext
    {
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Actor>? Actors { get; set; }
        public DbSet<Director>? Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=ruben\\sqlexpress; Initial Catalog=Streamer;Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Streamer>()
            //    .HasMany(s => s.Videos)
            //    .WithOne(v => v.Streamer)
            //    .HasForeignKey(v => v.StreamerId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(v => v.Actors)
                .WithMany(a => a.Videos)
                .UsingEntity<VideoActor>(
                    va => va.HasKey(x => new { x.VideoId, x.ActorId })
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}