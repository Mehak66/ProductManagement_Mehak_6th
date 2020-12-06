﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagement_Mehak_6th.BussLayer;
using ProductManagement_Mehak_6th.Data;

namespace ProductManagement_Mehak_6th.Pages.ProductManager
{
    public class EditModel : PageModel
    {
        private readonly ProductManagement_Mehak_6th.Data.ApplicationDbContext _context;

        public EditModel(ProductManagement_Mehak_6th.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BussLayer.ProductManager ProductManager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductManager = await _context.ProductManagers
                .Include(p => p.Product)
                .Include(p => p.Supplier).FirstOrDefaultAsync(m => m.ID == id);

            if (ProductManager == null)
            {
                return NotFound();
            }
           ViewData["ProductID"] = new SelectList(_context.Products, "ID", "Name");
           ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductManagerExists(ProductManager.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductManagerExists(int id)
        {
            return _context.ProductManagers.Any(e => e.ID == id);
        }
    }
}
