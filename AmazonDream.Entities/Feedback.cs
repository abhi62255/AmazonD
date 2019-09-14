using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("FEEDBACK")]
    public class Feedback
    {
        [Key]
        public long ID { get; set; }

        [Range(1, 5)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Review { get; set; }


        [ForeignKey("Product")]
        public long Product_ID { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Customer")]
        public long Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
