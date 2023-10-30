using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastucture.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static void AddDataVideoRepository(StreamerDbContext streamerDbContextMock)
        {
            Fixture fixture = new();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Video>().ToList();
            videos.Add(fixture.Build<Video>()
                .With(x => x.CreatedBy, "rubsanchez")
                .Create()
            );

            streamerDbContextMock.Videos!.AddRange(videos);
            streamerDbContextMock.SaveChanges();
        }
    }
}
