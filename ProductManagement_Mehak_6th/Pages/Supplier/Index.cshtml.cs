﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductManagement_Mehak_6th.BussLayer;
using ProductManagement_Mehak_6th.Data;

namespace ProductManagement_Mehak_6th.Pages.Supplier
{
    public class IndexModel : PageModel
    {
        private readonly ProductManagement_Mehak_6th.Data.ApplicationDbContext _context;

        public IndexModel(ProductManagement_Mehak_6th.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BussLayer.Supplier> Supplier { get;set; }

        public async Task OnGetAsync()
        {
            Supplier = await _context.Suppliers.ToListAsync();
        }
    }
}
