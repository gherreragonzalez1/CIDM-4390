using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceriesDelivery.Models;
using GroceriesDelivery.Data;

namespace GroceriesDelivery.Pages_Order
{
    public class CreateModel : PageModel
    {
        private readonly GroceriesDeliveryContext _context;

        public CreateModel(GroceriesDeliveryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DriverID"] = new SelectList(_context.Driver, "DriverID", "DriverID");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
