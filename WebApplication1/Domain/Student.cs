using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }

        public Group Group { get; set; }
    }
}
