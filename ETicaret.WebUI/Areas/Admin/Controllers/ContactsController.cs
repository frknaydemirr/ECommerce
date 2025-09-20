using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactsController : Controller
    {

       
        private readonly DatabaseContext _context;

        public ContactsController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Contacts);
        }
    }
}
