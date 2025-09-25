﻿using ECommerce.Core.Entities;
using ECommerce.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    public class NewsController : Controller
    {

        private readonly IService<News> _service;

        public NewsController(IService<News> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Admin/News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound("Geçersiz İstek!");
            }

            var news = await _service.GetAsync(m => m.Id == id && m.IsActive );
            if (news == null)
            {
                return NotFound("Geçerli bir kampanya bulunamadı!");
            }

            return View(news);
        }
    }
}
