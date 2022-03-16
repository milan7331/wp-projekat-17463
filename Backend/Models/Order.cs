using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Column("Quantity")]
        public int Quantity { get; set; }
        
        [Column("Price")]
        public int Price { get; set; }

        [JsonIgnore]
        [Required]
        [Column("Buyer")]
        public UserAccount Buyer { get; set; }

        [Required]
        [Column("Part")]
        public PCPart Part { get; set; }

        [Required]
        [Column("FromStore")]
        public PCStore FromStore { get; set; }
    }
}