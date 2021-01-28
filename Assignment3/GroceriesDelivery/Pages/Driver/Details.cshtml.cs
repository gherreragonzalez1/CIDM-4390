using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroceriesDelivery.Models;
using GroceriesDelivery.Data;

namespace GroceriesDelivery.Pages_Driver
{
    public class DetailsModel : PageModel
    {
        private readonly GroceriesDeliveryContext _context;

        public DetailsModel(GroceriesDeliveryContext context)
        {
            _context = context;
        }

        public Driver Driver { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Driver.FirstOrDefaultAsync(m => m.DriverID == id);

            if (Driver == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
