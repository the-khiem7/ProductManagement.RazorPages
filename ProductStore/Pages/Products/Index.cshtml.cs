using System;
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
    public class IndexModel : PageModel
    {
        private readonly IProductService _contextProduct;


        public IndexModel(IProductService context)
        {
            _contextProduct = context;
        }


        public IList<Product> Product { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Account")))
            {
                Product = _contextProduct.GetProducts();
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }

}
