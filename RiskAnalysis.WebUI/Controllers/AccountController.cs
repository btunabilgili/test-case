using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RiskAnalysis.Application.Auth;
using RiskAnalysis.Application.Authentication;
using RiskAnalysis.WebUI.Models;
using System.Security.Claims;

namespace RiskAnalysis.WebUI.Controllers
{
    public class AccountController(IAuthService authService, IMapper mapper) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userDto = mapper.Map<UserDto>(model);

            var result = await authService.ValidateUserAsync(userDto);

            if (result.IsError)
            {
                ModelState.AddModelError("", result.FirstError.Description);
                return View(model);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, result.Value.Username),
                new(ClaimTypes.Email, result.Value.Mail)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userDto = mapper.Map<UserDto>(model);

            var result = await authService.RegisterUserAsync(userDto);

            if (result.IsError)
            {
                ModelState.AddModelError("", result.FirstError.Description);
                return View(model);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, result.Value.Username),
                new(ClaimTypes.Email, result.Value.Mail)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
