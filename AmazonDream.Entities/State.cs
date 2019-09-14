using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("STATE")]
    public class State
    {
        [Key]
        public int ID { get; set; }
        public string StateName { get; set; }


        public virtual ICollection<City> City { get; set; }
    }
}
