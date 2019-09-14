using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class AddressModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Maximun length 500 character")]
        public string AddressLine { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public Int32 PostalCode { get; set; }

        public string AddressType { get; set; }

        public Nullable<int> Seller_ID { get; set; }

        public Nullable<int> Customer_ID { get; set; }
    }
}
