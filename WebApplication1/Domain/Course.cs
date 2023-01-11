namespace WebApplication1.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Group> Groups { get; set; } = new List<Group>();
    }
}
