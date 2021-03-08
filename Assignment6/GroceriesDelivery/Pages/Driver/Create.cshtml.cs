using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceriesDelivery.Models;
using GroceriesDelivery.Data;

namespace GroceriesDelivery.Pages_Driver
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
            return Page();
        }

        [BindProperty]
        public Driver Driver { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Driver.Add(driver);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Order/Index");
        }
    }
}
