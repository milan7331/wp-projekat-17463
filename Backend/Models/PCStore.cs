using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Stores")]
    public class PCStore
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [Phone]
        [Column("StorePhoneNumber")]
        public int StorePhoneNumber { get; set; }

        [Required]
        [Column("StoreLocation")]
        [MaxLength(150)]
        public string StoreLocation { get; set; }

        [Required]
        [Column("StoreMailAdress")]
        [EmailAddress]
        [MaxLength(100)]
        public string StoreMailAdress { get; set; }

        [Column("PartsAvailable")]
        public List<PCPart> PartsAvailable { get; set; }
    }
}