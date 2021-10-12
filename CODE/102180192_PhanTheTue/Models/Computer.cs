using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _102180192_PhanTheTue.Models
{
    [Table("Computer")]
    public class Computer
    {
        [Key]
        public int id {get; set;}

        [Required]
        [StringLength(200)]
        public string name  {get; set;}

        [Required]
        [StringLength(200)]
        public string type {get; set;}

        public int id_system { get; set; }
        [ForeignKey("id_system")]
        public virtual OperatingSystem OperatingSystem { get; set; }

    }
}