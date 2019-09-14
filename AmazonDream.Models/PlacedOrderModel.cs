using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class PlacedOrderModel
    {
        public long ID { get; set; }

        public string PaymentType { get; set; }

        public long Address_ID { get; set; }

        public int Customer_ID { get; set; }
    }
}
