﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement_Mehak_6th.BussLayer;
using ProductManagement_Mehak_6th.Data;

namespace ProductManagement_Mehak_6th.Pages.ProductManager
{
    public class CreateModel : PageModel
    {
        private readonly ProductManagement_Mehak_6th.Data.ApplicationDbContext _context;

        public CreateModel(ProductManagement_Mehak_6th.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Name");
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public BussLayer.ProductManager ProductManager { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductManagers.Add(ProductManager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
