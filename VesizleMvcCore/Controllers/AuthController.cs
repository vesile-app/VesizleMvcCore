using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using VesizleMvcCore.NodejsApi.Dtos;

namespace VesizleMvcCore.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<UserForLoginDto>(model);
            var result = await _authService.LoginAsync(dto);
            if (!result.IsSuccessful)
            {
                ModelState.AddModelError("Email", result.Message);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            return View();
        }
        [HttpGet]
        public void Logout()
        {
            //
        }
    }
}
