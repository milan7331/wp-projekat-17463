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
        [Column("StorePhoneNumber")]
        [MaxLength(15)]
        public int StorePhoneNumber { get; set; }

        [Required]
        [Column("StoreLocation")]
        [MaxLength(150)]
        public string StoreLocation { get; set; }

        [Required]
        [Column("StoreMailAdress")]
        [MaxLength(100)]
        public string StoreMailAdress { get; set; }

        [Column("PartsInStore")]
        public virtual List<PCPart> PartsInStore { get; set; }

    }
}