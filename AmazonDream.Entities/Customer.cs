using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazonDream.Entities
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(70)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }




        public virtual ICollection<Kart> Kart { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<PlacedOrder> PlacedOrder { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<PreVisit> PreVisit { get; set; }
        public virtual ICollection<SearchHistory> SearchHistories { get; set; }





    }
}
