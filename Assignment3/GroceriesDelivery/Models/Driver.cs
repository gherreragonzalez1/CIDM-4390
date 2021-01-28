using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceriesDelivery.Models
{
    public class Driver
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Username")]
        public string DriverID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string DriverPassword { get; set; }
        
        [Required]
        [Display(Name="Name")]
        public string DriverName { get; set; }

        [Required]
        [Display(Name="Phone")]
        public string DriverPhone { get; set; }
        
    }
}
