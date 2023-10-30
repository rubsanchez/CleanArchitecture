using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastucture.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextMock)
        {
            Fixture fixture = new();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var streamers = fixture.CreateMany<Streamer>().ToList();
            streamers.Add(fixture.Build<Streamer>()
                .With(x => x.Id, 9999)
                .Without(y => y.Videos)
                .Create()
            );

            streamerDbContextMock.Streamers!.AddRange(streamers);
            streamerDbContextMock.SaveChanges();
        }
    }
}
