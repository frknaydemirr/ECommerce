using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;
using ETicaret.WebUI.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class FavoritesController : Controller
    {

        private readonly IService<Product> _service;

        public FavoritesController(IService<Product> service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            var favoriler = GetFavorites();
            return View(favoriler);
        }

        //ürün listesini çekme: 

        private List<Product> GetFavorites()
        {
            return HttpContext.Session.GetJson<List<Product>>("GetFavorites") ?? new List<Product>();

        }
        [HttpPost]
        public IActionResult Add(int ProductId)
        {
            var favoriler = GetFavorites();
            var product = _service.Find(ProductId);

            if (product == null)
            {
                return Json(new { success = false, message = "Ürün bulunamadı!" });
            }

            if (!favoriler.Any(x => x.Id == ProductId))
            {
                favoriler.Add(product);
                HttpContext.Session.SetJson("GetFavorites", favoriler);

                return Json(new
                {
                    success = true,
                    message = $"{product.Name} favorilere eklendi!",
                    favoritesCount = favoriler.Count
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = $"{product.Name} zaten favorilerinizde!"
                });
            }
        }





        public IActionResult Remove(int ProductId)
        {
            var favoriler = GetFavorites();
            var product = _service.Find(ProductId);
            if (product != null && favoriler.Any(x => x.Id == ProductId))
            {
                favoriler.RemoveAll(i=>i.Id == ProductId);
                HttpContext.Session.SetJson("GetFavorites", favoriler);
            }
            return RedirectToAction("Index");
        }

    }
}
