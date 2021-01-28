using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GroceriesDelivery.Pages
{
    public class PortalModel : PageModel
    {
        private readonly ILogger<AdminModel> _logger;

        public PortalModel(ILogger<AdminModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
