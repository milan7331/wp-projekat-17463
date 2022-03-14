using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("UserAccount")]
    public class UserAccount
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        [Required]
        [Column("FirstName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("City")]
        [MaxLength(40)]
        public string City { get; set; }

        [Required]
        [Column("Address")]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [Column("PostalCode")]
        [Range(10000,50000)]
        public int PostalCode { get; set; }

        [Required]
        [Column("PhoneNumber")]
        [MaxLength(15)]
        public int PhoneNumber { get; set; }

        [Required]
        [Column("MailAddress")]
        [MaxLength(320)]
        public string MailAddress { get; set; }

        [Column("Orders")]
        public List<Order> Orders { get; set; }
    }
}