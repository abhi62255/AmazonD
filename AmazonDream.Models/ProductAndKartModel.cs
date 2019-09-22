using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class ProductAndKartModel
    {
        public long ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTime { get; set; }
        
        public long Product_ID { get; set; }

        public string ProductName { get; set; }

        public long ProductPrice { get; set; }

        public int ProductDiscount { get; set; }

        public long Amount { get; set; }

        public string PicturePath { get; set; }



    }
}
