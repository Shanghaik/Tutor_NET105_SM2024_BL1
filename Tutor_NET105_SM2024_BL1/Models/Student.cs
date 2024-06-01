using System.ComponentModel.DataAnnotations;

namespace Tutor_NET105_SM2024_BL1.Models
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
