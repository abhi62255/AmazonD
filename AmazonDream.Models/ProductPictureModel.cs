using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class ProductPictureModel
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public string PicturePath { get; set; }

        [Required]
        public long Product_ID { get; set; }
    }
}
