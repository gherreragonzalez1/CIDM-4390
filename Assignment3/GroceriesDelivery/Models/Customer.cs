using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceriesDelivery.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Username")]
        public string CustID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string CustPassword { get; set; }
        
        [Required]
        [Display(Name="Name")]
        public string CustName { get; set; }

        [Required]
        [Display(Name="Address")]
        public string CustAddress { get; set; }

        [Required]
        [Display(Name="Email")]
        public string CustEmail { get; set; }

        [Required]
        [Display(Name="Phone")]
        public string CustPhone { get; set; }
        
    }
}
