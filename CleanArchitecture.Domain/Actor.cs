using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Actor : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public virtual ICollection<Video>? Videos { get; set; }


        public Actor()
        {
            Videos = new HashSet<Video>();
        }
    }
}