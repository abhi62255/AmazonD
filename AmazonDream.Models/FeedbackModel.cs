using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazonDream.ViewModels
{
    public class FeedbackModel
    {
        public long ID { get; set; }

        [Range(1, 5)]
        [Required]
        public int Rating { get; set; }

        [Required]
        [MaxLength(5000, ErrorMessage = "Maximum length of 5000 Character")]
        public string Review { get; set; }
        public long Product_ID { get; set; }
        public int Customer_ID { get; set; }
    }
}
