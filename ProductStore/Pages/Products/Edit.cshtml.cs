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
using ProductStore.Models;
using Services.Interfaces;

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

            var product = await _context.GetProductByIdAsync((int)id);
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

            ViewData["CategoryId"] = new SelectList(await _categoryService.GetCategoriesAsync(), "CategoryId", "CategoryName");
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
                await _context.UpdateProductAsync(newProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(Product.ProductId))
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


        private async Task<bool> ProductExists(int id)
        {
            return (await _context.GetProductByIdAsync(id)) == null ? true : false;
        }
    }

}
