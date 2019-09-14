using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class KartModel
    {
 
        [Required]
        public int Quantity { get; set; }

        public long Product_ID { get; set; }
        public long Customer_ID { get; set; }
    }
}
