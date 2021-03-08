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
    public class DeleteModel : PageModel
    {
        private readonly GroceriesDeliveryContext _context;

        public DeleteModel(GroceriesDeliveryContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Driver.FindAsync(id);

            if (Driver != null)
            {
                _context.Driver.Remove(Driver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
