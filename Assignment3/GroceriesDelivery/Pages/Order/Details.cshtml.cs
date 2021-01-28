using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceriesDelivery.Models;
using GroceriesDelivery.Data;

namespace GroceriesDelivery.Pages_Order
{
    public class DetailsModel : PageModel
    {
        private readonly GroceriesDeliveryContext _context;

        public DetailsModel(GroceriesDeliveryContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.Driver).FirstOrDefaultAsync(m => m.OrderID == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
