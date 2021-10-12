using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _102180192_PhanTheTue.Models
{
    [Table("OperatingSystem")]
    public class OperatingSystem
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(200)]
        public string name { get; set; }
    }
}
