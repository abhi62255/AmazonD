using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("WISHLIST")]
    public class Wishlist
    {
        [Key]
        public long ID { get; set; }

        [ForeignKey("Product")]
        public long Product_ID { get; set; }
        public virtual Product Product { get; set; }



        [ForeignKey("Customer")]
        public long Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
