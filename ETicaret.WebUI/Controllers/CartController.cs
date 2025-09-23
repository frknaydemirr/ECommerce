using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;
using ECommerce.Service.Concrete;
using ETicaret.WebUI.ExtensionMethods;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class CartController : Controller
    {

        private readonly IService<Product> _service;

        public CartController(IService<Product> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            CartViewModel model = new CartViewModel()
            {
                cartLines = cart.CartLines,
                TotalPrice = cart.TotalPrice()

            };
            return View(model);
        }

        //Kart Bilgilerini Getirsin:
        private CartService GetCart()
        {
            return HttpContext.Session.GetJson<CartService>("Cart") ?? new CartService();
        }


        public IActionResult Add(int ProductId, int Quantity = 1)
        {
            var product = _service.Find(ProductId);
            if (product != null) // ürün bulunduysa
            {
                var cart = GetCart();
                cart.AddProduct(product, Quantity);
                HttpContext.Session.SetJson("Cart", cart);
                return Redirect(Request.Headers["Referer"].ToString());
                //kullanıcının buraya gelmeden bi önceki sayfasına yönlendiriyor
                //daha iyi bir kullanıcı deneyimi yaşatırız!
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int ProductId, int Quantity = 1)
        {
            var product = _service.Find(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.UpdateProduct(product, Quantity);
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int ProductId)
        {
            var product = _service.Find(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }


    }
}
