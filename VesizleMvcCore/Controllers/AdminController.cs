using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Models;

namespace VesizleMvcCore.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class AdminController : Controller
    {
        private UserManager<VesizleUser> _userManager;
        private RoleManager<VesizleRole> _roleManager;
        private IMapper _mapper;
        private SignInManager<VesizleUser> _signInManager;
        public AdminController(UserManager<VesizleUser> userManager, IMapper mapper, RoleManager<VesizleRole> roleManager, SignInManager<VesizleUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            UserListViewModel model = new UserListViewModel();

            foreach (var user in users)
            {
                var userDetail = new UserDetailForAdminModel
                {
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    UserName = user.UserName

                };
                userDetail.CurrentRoles = (List<string>)(await _userManager.GetRolesAsync(user));
                userDetail.SelectRoles = _mapper.Map<List<SelectListItem>>(_roleManager.Roles.Where(role => !userDetail.CurrentRoles.Contains(role.Name)));
                model.Users.Add(userDetail);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRole(UserListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(
                    user => user.Id == model.AddUserRoleModel.UserId);
                var role =
                    await _roleManager.Roles.FirstOrDefaultAsync(role => role.Id == model.AddUserRoleModel.RoleId);
                await _userManager.AddToRoleAsync(user, role.Name);
                if (HttpContext.User.Identity.Name == user.UserName)
                {
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user, true);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUserRole(UserListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(
                    user => user.Id == model.RemoveUserRoleModel.UserId);
                await _userManager.RemoveFromRoleAsync(user, model.RemoveUserRoleModel.RoleName);
                if (HttpContext.User.Identity.Name == user.UserName)
                {
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user, true);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
