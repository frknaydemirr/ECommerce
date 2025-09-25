using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;
using ECommerce.Service.Concrete;
using ETicaret.WebUI.ExtensionMethods;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Controllers
{
    public class CartController : Controller
    {
          private readonly IService<AppUser> _serviceAppUser;
        private readonly IService<Product> _serviceProduct;
        private readonly IService<Address> _serviceAddress;
        private readonly IService<Order> _serviceOrder;

        public CartController(IService<Product> service, IService<Address> serviceAddress, IService<AppUser> serviceAppUser, IService<Order> serviceOrder)
        {
            _serviceProduct = service;
            _serviceAddress = serviceAddress;
            _serviceAppUser = serviceAppUser;
            _serviceOrder = serviceOrder;
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
            var product = _serviceProduct.Find(ProductId);
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
            var product = _serviceProduct.Find(ProductId);
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
            var product = _serviceProduct.Find(ProductId);
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }


        [Authorize]
        public  async Task<IActionResult> CheckOut()
        {
            var cart = GetCart();
            var appUser = await _serviceAppUser.GetAsync(x=>x.UserGuid.ToString()==User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var addresses = await _serviceAddress.GetAllAsync(a => a.AppUserId == appUser.Id && a.IsActive);
            CheckOutViewModel model = new CheckOutViewModel()
            {
                CartProducts = cart.CartLines,
                TotalPrice = cart.TotalPrice(),
                Addresses= addresses

            };
            return View(model);
        }



        //Sipariş Oluşturacağız:
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CheckOut(string CardNumber,string CardMonth, string CardYear , 
            string CCV,string DeliveryAddress, string BillingAddress)
        {
            var cart = GetCart();
            var appUser = await _serviceAppUser.GetAsync(x => x.UserGuid.ToString() == User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var addresses = await _serviceAddress.GetAllAsync(a => a.AppUserId == appUser.Id && a.IsActive);
            CheckOutViewModel model = new CheckOutViewModel()
            {
                CartProducts = cart.CartLines,
                TotalPrice = cart.TotalPrice(),
                Addresses = addresses

            };
            if (string.IsNullOrWhiteSpace(CardNumber) || string.IsNullOrWhiteSpace(CardYear) ||
                string.IsNullOrWhiteSpace(CCV) || string.IsNullOrWhiteSpace(DeliveryAddress) ||
                string.IsNullOrWhiteSpace(BillingAddress))
            {
                return View(model);
            }
            var teslimatAdresi = addresses.FirstOrDefault(a => a.AdressGuid.ToString() == DeliveryAddress);
            var faturaAdresi = addresses.FirstOrDefault(a => a.AdressGuid.ToString() == BillingAddress);

            //Ödeme Çekme İşlemi


            var siparis = new Order()
            {
                BillingAddress = $"{faturaAdresi.OpenAdress}  {faturaAdresi.District}   {faturaAdresi.City} " ,
                AppUserId = appUser.Id,
                CustomerId = appUser.UserGuid.ToString(),
                DeliveryAddress = $"{faturaAdresi.OpenAdress}  {faturaAdresi.District}   {faturaAdresi.City} ",
                OrderDate = DateTime.Now,
                TotalPrice = cart.TotalPrice(),
                OrderNumber = Guid.NewGuid().ToString(),
                OrderState=0, //onay bekliyor
                OrderLines = new List<OrderLine>()
            };

            foreach (var item in cart.CartLines)
            {
                siparis.OrderLines.Add(new OrderLine()
                {
                    ProductId = item.Product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price
                });
            }

            try
            {
                await _serviceOrder.AddAsync(siparis);
                var sonuc = await _serviceOrder.SaveChangesAsync();
                if (sonuc > 0)
                {
                    HttpContext.Session.Remove("Cart");
                    return RedirectToAction("Thanks");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Hata Oluştu! " + ex.InnerException?.Message;
            }





            return View(model);
        }



        public IActionResult Thanks()
        {
          
            return View();
        }



    }
}
