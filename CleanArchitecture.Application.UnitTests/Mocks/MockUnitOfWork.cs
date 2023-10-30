using CleanArchitecture.Infrastucture.Persistence;
using CleanArchitecture.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;

            StreamerDbContext streamerDbContextMock = new(options);
            streamerDbContextMock.Database.EnsureDeleted();

            Mock<UnitOfWork> mockUnitOfWork = new(streamerDbContextMock);

            return mockUnitOfWork;
        }
    }
}
