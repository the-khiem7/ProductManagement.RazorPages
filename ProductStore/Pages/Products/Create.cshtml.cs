using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussiessObjects;
using BussiessObjects.Entities;
using Services;
using ProductStore.Models;
using Microsoft.AspNetCore.SignalR;
using ProductStore.SignalRLab;

namespace ProductStore.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _contextProduct;
        private readonly ICategoryService _contextCategory;
        private readonly IHubContext<SignalrServer> _hubContext;
        public CreateModel(IProductService context, ICategoryService categoryService, IHubContext<SignalrServer> hubContext)
        {
            _contextProduct = context;
            _contextCategory = categoryService;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_contextCategory.GetCategories(), "CategoryId", "CategoryId");
            return Page();
        }


        [BindProperty]
        public CreateProductDTO Product { get; set; } = default!;
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product newProduct = new()
            {
                ProductName = Product.ProductName,
                CategoryId = Product.CategoryId,
                UnitsInStock = Product.UnitsInStock,
                UnitPrice = Product.UnitPrice,
            };
            _contextProduct.SaveProduct(newProduct);
            await _hubContext.Clients.All.SendAsync("LoadAllItems");

            return RedirectToPage("./Index");
        }
    }
}
