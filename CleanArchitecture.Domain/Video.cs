using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Video : BaseDomainModel
    {
        public string? Name { get; set; }
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual Director Director { get; set; }

        public Video()
        {
            Actors = new HashSet<Actor>();
        }
    }
}