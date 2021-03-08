using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceriesDelivery.Models;
using GroceriesDelivery.Data;

namespace GroceriesDelivery.Pages_Customer
{
    public class IndexModel : PageModel
    {
        private readonly GroceriesDeliveryContext _context;

        public IndexModel(GroceriesDeliveryContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get;set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customer.ToListAsync();
        }
    }
}
