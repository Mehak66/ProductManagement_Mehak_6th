using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductManagement_Mehak_6th.BussLayer;
using ProductManagement_Mehak_6th.Data;

namespace ProductManagement_Mehak_6th.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly ProductManagement_Mehak_6th.Data.ApplicationDbContext _context;

        public DetailsModel(ProductManagement_Mehak_6th.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public BussLayer.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
