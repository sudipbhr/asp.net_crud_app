using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
