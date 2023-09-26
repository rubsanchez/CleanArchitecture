namespace CleanArchitecture.Domain
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int StreamerId { get; set; }
        public virtual Streamer Streamer { get; set; }
    }
}