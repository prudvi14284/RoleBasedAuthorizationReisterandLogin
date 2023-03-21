﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.Models.DTO;
using RoleBasedAuthorization.Repositories.Abstract;

namespace RoleBasedAuthorization.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;

        public UserAuthenticationController(IUserAuthenticationService service)
        {
            this._service = service;
        }

        public IActionResult Registration()
        {
            return View();
        }

        //Registration Post
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result = await _service.RegistrationModel(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));

        }

        public IActionResult Login()
        {
            return View();
        }

        //Login Post
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }



        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Reg()
        {
            var model = new RegistrationModel()
            {
                UserName = "admin",
                Name = "Prudvi Raj",
                Email = "prudvi@gmail.com",
                Password = "Admin@12345"
            };
            model.Role = "admin";
            var result = await _service.RegistrationModel(model);
            return Ok(result);
        }

    }
}
