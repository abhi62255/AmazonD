using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("SEARCHHISTORY")]
    public class SearchHistory
    {
        [Key]
        public long ID { get; set; }
        public string SearchTag { get; set; }
        public DateTime Date { get; set; }


        [ForeignKey("Customer")]
        public long Customer_ID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
