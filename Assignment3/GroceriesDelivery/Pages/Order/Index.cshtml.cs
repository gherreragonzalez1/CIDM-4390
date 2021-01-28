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
    public class IndexModel : PageModel
    {
        private readonly GroceriesDeliveryContext _context;

        public IndexModel(GroceriesDeliveryContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Driver).ToListAsync();
        }
    }
}
