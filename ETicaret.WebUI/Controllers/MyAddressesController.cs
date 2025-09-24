using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.WebUI.Controllers
{

    [Authorize]
    public class MyAddressesController : Controller
    {


        private readonly IService<AppUser> _serviceAppUser;
        private readonly IService<Address> _serviceAddress;

        public MyAddressesController(IService<AppUser> service, IService<Address> service1)
        {
            _serviceAppUser = service;
            _serviceAddress = service1;
        }

        public async Task<IActionResult> Index()
        {
            var appUser = await _serviceAppUser.GetAsync(x=>x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Datası Bulunamadı!  Oturumunuzu Kapatıp Tekrar Giriş Yapın!");

            }
            var model = await _serviceAddress.GetAllAsync(x => x.AppUserId == appUser.Id);
            return View(model);
        }


        public IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address address)
        {
            try
            {
                var appUser = await _serviceAppUser.GetAsync(x => x.UserGuid.ToString() == HttpContext.User.FindFirst("UserGuid").Value);
                if (appUser !=null)
                {
                    address.AppUserId = appUser.Id;
                    _serviceAddress.Add(address);
                    await _serviceAddress.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ModelState.AddModelError("", "Kayıt Başarısız!");
            return View(address);
        }




        public async Task<IActionResult> Edit(string id)
        {
            var appUser = await _serviceAppUser.GetAsync(x => x.UserGuid.ToString() == 
            HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Datası Bulunamadı!  Oturumunuzu Kapatıp Tekrar Giriş Yapın!");

            }
            var model = await _serviceAddress.GetAsync(x => x.AdressGuid.ToString() == id && 
            x.AppUserId == appUser.Id);
            if(model == null)
            {
                return NotFound("Adress Datası Bulunamadı!");

            }
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Address address)
        {
            var appUser = await _serviceAppUser.GetAsync(x => x.UserGuid.ToString() ==
                HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Datası Bulunamadı!  Oturumunuzu Kapatıp Tekrar Giriş Yapın!");
            }
            var model = await _serviceAddress.GetAsync(x => x.AdressGuid.ToString() == id &&
                x.AppUserId == appUser.Id);
            if (model == null)
            {
                return NotFound("Adress Datası Bulunamadı!");
            }

            model.Title = address.Title;
            model.District = address.District;
            model.City = address.City;
            model.OpenAdress = address.OpenAdress;
            model.isDeliveryAdress = address.isDeliveryAdress;
            model.isBilllingAdress = address.isBilllingAdress;
            model.IsActive = address.IsActive;

            // If this address is set as delivery or billing, unset others
            if (model.isDeliveryAdress || model.isBilllingAdress)
            {
                var otherAddresses = await _serviceAddress.GetAllAsync(x => x.AppUserId == appUser.Id && x.Id != model.Id);
                foreach (var item in otherAddresses)
                {
                    if (model.isDeliveryAdress)
                        item.isDeliveryAdress = false;
                    if (model.isBilllingAdress)
                        item.isBilllingAdress = false;
                    _serviceAddress.Update(item);
                }
            }

            try
            {
                _serviceAddress.Update(model);
                await _serviceAddress.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }

            return View(model);
        }












        public async Task<IActionResult> Delete(string id)
        {
            var appUser = await _serviceAppUser.GetAsync(x => x.UserGuid.ToString() ==
                HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Datası Bulunamadı! Oturumunuzu Kapatıp Tekrar Giriş Yapın!");
            }

            var model = await _serviceAddress.GetAsync(x => x.AdressGuid.ToString() == id &&
                x.AppUserId == appUser.Id);
            if (model == null)
            {
                return NotFound("Adres Datası Bulunamadı!");
            }

            return View(model); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, Address address)
        {
            var appUser = await _serviceAppUser.GetAsync(x => x.UserGuid.ToString() ==
                HttpContext.User.FindFirst("UserGuid").Value);
            if (appUser == null)
            {
                return NotFound("Kullanıcı Datası Bulunamadı!  Oturumunuzu Kapatıp Tekrar Giriş Yapın!");
            }
            var model = await _serviceAddress.GetAsync(x => x.AdressGuid.ToString() == id &&
                x.AppUserId == appUser.Id);
            if (model == null)
            {
                return NotFound("Adress Datası Bulunamadı!");
            }
            try
            {
                _serviceAddress.Delete(model);
                await _serviceAddress.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }

            return View(model);
        }

    }
}
