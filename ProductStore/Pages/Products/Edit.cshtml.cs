using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussiessObjects;
using BussiessObjects.Entities;
using Services;
using ProductStore.Models;

namespace ProductStore.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _context;
        private readonly ICategoryService _categoryService;

        public EditModel(IProductService context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [BindProperty]
        public UpdateProductDTO Product { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await Task.Run(() => _context.GetProductById((int)id));
            if (product == null)
            {
                return NotFound();
            }

            Product = new UpdateProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice
            };

            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName");
            return Page();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product newProduct = new Product
            {
                ProductId = Product.ProductId,
                ProductName = Product.ProductName,
                CategoryId = Product.CategoryId,
                UnitsInStock = Product.UnitsInStock,
                UnitPrice = Product.UnitPrice
            };
            try
            {
                _context.UpdateProduct(newProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
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


        private bool ProductExists(int id)
        {
            return (_context.GetProductById(id) == null) ? true : false;
        }
    }

}
