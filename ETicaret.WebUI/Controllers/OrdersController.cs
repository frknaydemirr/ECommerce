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
    public class OrdersController : Controller
    {
        private readonly IService<AppUser> _serviceAppUser;
        private readonly IService<Product> _serviceProduct;
        private readonly IService<Address> _serviceAddress;
        private readonly IService<Order> _serviceOrder;

        public OrdersController(IService<Product> service, IService<Address> serviceAddress, IService<AppUser> serviceAppUser, IService<Order> serviceOrder)
        {
            _serviceProduct = service;
            _serviceAddress = serviceAddress;
            _serviceAppUser = serviceAppUser;
            _serviceOrder = serviceOrder;
        }

        //claims tabanlı:
        public async Task<IActionResult> Index()
        {
            

            return View();
        }





    }
}
