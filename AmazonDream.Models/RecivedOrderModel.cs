using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class RecivedOrderModel
    {
        public long ID { get; set; }
        public long Product_ID { get; set; }
        public string ProductName { get; set; }
        public long OrderNumber { get; set; }
        public long Quantity { get; set; }
        public long Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }

    }
}
