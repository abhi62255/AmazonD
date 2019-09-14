using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("PREVISIT")]
    public class PreVisit
    {
        [Key]
        public long ID { get; set; }
        public DateTime Date { get; set; }


        [ForeignKey("Product")]
        public long Product_ID { get; set; }
        public virtual Product Product { get; set; }



        [ForeignKey("Customer")]
        public long Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
