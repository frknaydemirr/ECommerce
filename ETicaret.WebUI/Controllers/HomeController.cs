using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaret.WebUI.Controllers
{
    public class HomeController : Controller
        //birden fazla tablodan veri alacaðýmýz için ayrý ayrý ekleriz:
    {
        private readonly IService<Product> _serviceProduct;
        private readonly IService<News> _serviceNews;
        private readonly IService<Slider> _serviceSlider;
        private readonly IService<Contact> _serviceContact;


        public HomeController(
            IService<Product> serviceProduct,
            IService<News> serviceNews,
            IService<Slider> serviceSlider,
            IService<Contact> serviceContact)
        {
            _serviceProduct = serviceProduct;
            _serviceNews = serviceNews;
            _serviceSlider = serviceSlider;
            _serviceContact = serviceContact;
        }

        //datayý anasayfaya gönderdik!
        public async Task<IActionResult> Index()
        {  
            var model = new HomePageViewModel()
            {
                Sliders= await _serviceSlider.GetAllAsync(),
                News = await _serviceNews.GetAllAsync(news =>news.IsActive),
                Products = await _serviceProduct.GetAllAsync(x => x.IsActive && x.IsHome),
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> ContactUs()
        {
           
            return View();
        }

        



        [HttpPost]
        public   async Task<IActionResult> ContactUsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  await   _serviceContact.AddAsync(contact);
                    var sonuc = await _serviceContact.SaveChangesAsync();
                    if (sonuc > 0)
                    {
                        TempData["Message"] = @"
<div class='alert alert-success alert-dismissible fade show' role='alert'>
    <strong>Mesajýnýz Gönderilmiþtir!</strong> 
    <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>
</div>";

                     //await   MailHelper.SendMailAsync(contact);


                        return RedirectToAction("ContactUs");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluþtu!");
                }
            }
            return View(contact);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
