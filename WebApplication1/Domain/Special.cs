namespace WebApplication1.Domain
{
    public class Special
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IList<Group> Groups { get; set; } = new List<Group>();
    }
}
