using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastucture.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
        }

        public async Task<Video> GetVideoByName(string name)
        {
            return await _context.Videos!.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUserName(string username)
        {
            return await _context.Videos!.Where(x => x.CreatedBy == username).ToListAsync();
        }
    }
}
