using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonDream.Entities
{
    [Table("SELLER")]
    public class Seller
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Maximun length 200 character")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "Maximun length 100 character")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minmum length 6 character")]
        [MaxLength(50, ErrorMessage = "Maximun length 50 character")]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }



        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Address> Address { get; set; }


    }
}
