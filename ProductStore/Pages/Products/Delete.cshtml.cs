﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussiessObjects;
using BussiessObjects.Entities;
using Services.Interfaces;

namespace ProductStore.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _context;

        public DeleteModel(IProductService context)
        {
            _context = context;
        }


        [BindProperty]
        public Product Product { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.GetProductByIdAsync((int)id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.GetProductByIdAsync((int)id);
            if (product != null)
            {
                Product = product;
                await _context.DeleteProductAsync(product);
            }

            return RedirectToPage("./Index");
        }
    }

}
