using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastucture.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Added records into db {context}", typeof(StreamerDbContext));
            }

        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>()
            {
                new Streamer() { CreatedBy = "rubsanchez", Name = "HBO Max", Url = "http://www.hbomax.com" },
                new Streamer() { CreatedBy = "rubsanchez", Name = "Plex", Url = "http://www.plex.com"}
            };
        }
    }
}
