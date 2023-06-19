using System.ComponentModel.DataAnnotations;

namespace HalSecurityTrainingWeb.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
