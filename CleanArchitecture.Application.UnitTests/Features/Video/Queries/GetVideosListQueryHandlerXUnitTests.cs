using AutoMapper;
using CleanArchitecture.Application.Features.Videos.Queries;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastucture.Repositories;
using Moq;
using Shouldly;

namespace CleanArchitecture.Application.UnitTests.Features.Video.Queries
{
    public class GetVideosListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;


        public GetVideosListQueryHandlerXUnitTests()
        {
            MapperConfiguration mapperConfig = new(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            MockVideoRepository.AddDataVideoRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task GetVideoListTest()
        {
            GetVideosListQueryHandler handler = new(_unitOfWork.Object, _mapper);
            GetVideosListQuery query = new("rubsanchez");

            var res = await handler.Handle(query, CancellationToken.None);

            res.ShouldBeOfType<List<VideoDto>>();
            res.Count.ShouldBe(1);
        }
    }
}