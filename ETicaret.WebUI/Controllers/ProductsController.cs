using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Controllers
{
    public class ProductsController : Controller
    {


        private readonly IService<Product> _service;

        public ProductsController(IService<Product> service)
        {
            _service = service;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index(string q  = ""  )
        {
            var databaseContext = _service.GetAllAsync(p => p.IsActive &&
            p.Name.Contains(q) || p.Description.Contains(q));
               
            return View(await databaseContext);
        }



        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetQueryable()
                .Include(p => p.Brand)
                .Include(p => p.Category)
                 .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductDetailViewModel()
            {
                Product = product,
                RelatedProducts = _service.GetQueryable().Where(P => P.IsActive && 
                P.CategoryId==product.CategoryId && P.Id !=product.Id)

            };
            return View(model);
        }






    }

}