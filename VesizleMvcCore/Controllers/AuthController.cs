using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Extensions;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.Api.Abstract;

namespace VesizleMvcCore.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<VesizleUser> _userManager;
        private SignInManager<VesizleUser> _signInManager;
        private IPasswordHasher<VesizleUser> _passwordHasher;
        private IPasswordValidator<VesizleUser> _passwordValidator;
        private IUserValidator<VesizleUser> _userValidator;
        private IMapper _mapper;
        public AuthController(UserManager<VesizleUser> userManager, IMapper mapper, IPasswordValidator<VesizleUser> passwordValidator, IPasswordHasher<VesizleUser> passwordHasher, SignInManager<VesizleUser> signInManager, IUserValidator<VesizleUser> userValidator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
            _signInManager = signInManager;
            _userValidator = userValidator;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                VesizleUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //todo:notification
                }
                ModelState.AddModelError(nameof(model.Email), Messages.LoginFailed);
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<VesizleUser>(model);
                var identityResult = await _passwordValidator.ValidateAsync(_userManager, user, model.Password);
                if (identityResult.Succeeded)
                {
                    var validateResult = await _userValidator.ValidateAsync(_userManager, user);
                    if (validateResult.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                        var createResult = await _userManager.CreateAsync(user);
                        //var roleAddResult = await _userManager.AddToRoleAsync(user, UserRoles.Standard);
                        if (createResult.Succeeded /*&& roleAddResult.Succeeded*/)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        ModelState.AddIdentityError(createResult.Errors);
                        //ModelState.AddIdentityError(roleAddResult.Errors);
                        return View(model);
                    }
                    ModelState.AddIdentityError(validateResult.Errors);
                    return View(model);
                }
                ModelState.AddIdentityError(nameof(model.Password),identityResult.Errors);
                return View(model);
            }

            return View(model);
        }
    }
}
