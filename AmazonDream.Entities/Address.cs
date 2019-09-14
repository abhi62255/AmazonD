using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("ADDRESS")]
    public class Address
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string AddressLine { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public Int32 PostalCode { get; set; }

        public string AddressType { get; set; }

        [ForeignKey("Seller")]
        public Nullable<long> Seller_ID { get; set; }
        public virtual Seller Seller { get; set; }

        [ForeignKey("Customer")]
        public Nullable<long> Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
