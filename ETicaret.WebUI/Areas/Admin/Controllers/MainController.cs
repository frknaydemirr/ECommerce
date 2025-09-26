using ECommerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class MainController : Controller
    {


        private readonly DatabaseContext _context;

        public MainController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Products = _context.Products;

            return View();
        }
    }
}
