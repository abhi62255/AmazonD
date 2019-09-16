using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class Seller_AddressModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Int32 PostalCode { get; set; }

        public string AddressType { get; set; }

        public Nullable<int> Address_ID { get; set; }
    }
}
