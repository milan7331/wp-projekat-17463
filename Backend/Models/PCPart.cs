using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("PCPart")]
    public class PCPart
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Column("SerialNumber")]
        [Range(0,10000)]
        public int SerialNumber { get; set; }

        [Required]
        [Column("ProductName")]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        [Column("ProductCategory")]
        [MaxLength(30)]
        public string ProductCategory { get; set; }

        [Required]
        [Column("Price")]
        [Range(0,500000)]
        public int Price { get; set; }

        [Column("InStores")]
        public List<PCStore> InStores { get; set; }
    }
}