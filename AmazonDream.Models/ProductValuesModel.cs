using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class ProductValuesModel
    {
        [Key]
        public long ID { get; set; }


        [Required]
        public long ProductPrice { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public int ProductDiscount { get; set; }
    }
}
