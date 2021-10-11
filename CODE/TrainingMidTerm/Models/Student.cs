using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingMidTerm.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int id {get; set;}

        [Required]
        [StringLength(200)]
        public string name  {get; set;}

        [Required]
        [StringLength(200)]
        public string email {get; set;}

    }
}