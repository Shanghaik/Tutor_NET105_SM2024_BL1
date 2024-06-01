using System.ComponentModel.DataAnnotations;

namespace CRUD_API.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Major { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
    }
}
