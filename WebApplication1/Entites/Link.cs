using WebApplication1.Enums;

namespace WebApplication1.Entites
{
    public class Link
    { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public Platform PlatformId { get; set; }
    }
}
