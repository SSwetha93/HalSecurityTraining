using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalSecurityTrainingWeb.Models
{
    public class Employee
    {
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
		[DataType(DataType.Date)]
		public DateTime RegistrationDate { get; set; }
    }
}
