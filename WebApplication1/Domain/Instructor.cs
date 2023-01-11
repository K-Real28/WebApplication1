namespace WebApplication1.Domain
{
    public class Instructor
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Phone { get; set; }

        public Group Group { get; set; }

    }
}
