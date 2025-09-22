using ECommerce.Core.Entities;
using ECommerce.Data;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks; //-> login

namespace ETicaret.WebUI.Controllers
{
    public class AccountController : Controller
    {


        private readonly DatabaseContext _context;

        public AccountController(DatabaseContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            AppUser user= _context.AppUsers.FirstOrDefault(x=>x.UserGuid.ToString()== HttpContext.User
            .FindFirst("UserGuid").Value);
            if(user is null)
            {
                return NotFound();
            }
            var model= new UserEditViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password
            };
            return View(model);
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = await _context.AppUsers.FirstOrDefaultAsync(x =>
                        x.Email == loginViewModel.Email &&
                        x.Password == loginViewModel.Password &&
                        x.isActive);

                    if (account == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız");
                    }
                    else
                    {
                        var claims = new List<Claim>()
                {
                    new (ClaimTypes.Name, account.Name),
                    new (ClaimTypes.Role, account.isAdmin ? "Admin" : "Customer"),
                    new (ClaimTypes.Email, account.Email ),
                    new ("UserId", account.Id.ToString()),
                    new ("UserGuid", account.UserGuid.ToString())
                };

                        var userIdentity = new ClaimsIdentity(claims, "login");
                        var userPrincipal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(userPrincipal);
                        return Redirect(string.IsNullOrEmpty(loginViewModel.ReturnUrl) ?  "/" :
                            loginViewModel.ReturnUrl
                            );
                    }


                }
                catch (Exception)
                {
                    // logging
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(AppUser appUser)
        {
            appUser.isAdmin = false;
            appUser.isActive = true;
            if (ModelState.IsValid)
            {
              await  _context.AddAsync(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }


        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }

        [HttpPost,Authorize]
        public IActionResult Index(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
           AppUser user = _context.AppUsers.FirstOrDefault(x => x.UserGuid.ToString() == HttpContext.User
          .FindFirst("UserGuid").Value);
                    if( user is not null)
                    {
                        user.SurName = model.SurName;
                        user.Phone = model.Phone;
                        user.Name = model.Name;
                        user.Password = model.Password;
                        user.Email = model.Email;
                        _context.AppUsers.Update(user);
                        var sonuc= _context.SaveChanges();
                        if (sonuc > 0)
                        {
                            TempData["Message"] = @"
<div class='alert alert-success alert-dismissible fade show' role='alert'>
    <strong>Kayıt Bilgileriniz Güncellenmiştir!</strong> 
    <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>
</div>";

                            


                            return RedirectToAction("Index");
                        }
                    }

                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata oluştu!");
                }
            }

            return View();
        }

    }
}
