using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceriesDelivery.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        
        [Required]
        [Display(Name="Schedule Groceries Delivery")]
        public DateTime OrderDateCreated { get; set; }

        [Display(Name="Order Status")]
        public string OrderStatus { get; set; }

        [Display(Name="Customer Username")]
        public string CustID { get; set; }

        [Display(Name="Choose a Driver")]
        public string DriverID { get; set; }

        public Customer Customer { get; set; }

        public Driver Driver { get; set; }
        
    }
}
