using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class PreVisitModel
    {
       
        public long ID { get; set; }

        [Required]
        public long Product_ID { get; set; }

        [Required]
        public long Customer_ID { get; set; }
    }
}
