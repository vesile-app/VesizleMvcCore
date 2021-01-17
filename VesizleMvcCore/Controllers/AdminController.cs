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
using VesizleMvcCore.DataAccess.RoleDal;
using VesizleMvcCore.DataAccess.UserDal;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Models;

namespace VesizleMvcCore.Controllers
{
    //[Authorize(Roles = "Admin,Manager")]
    public class AdminController : Controller
    {
        private UserManager<VesizleUser> _userManager;
        private RoleManager<VesizleRole> _roleManager;
        private IMapper _mapper;
        private SignInManager<VesizleUser> _signInManager;
        private IUserDal _userDal;
        private IRoleDal _roleDal;
        public AdminController(UserManager<VesizleUser> userManager, IMapper mapper, RoleManager<VesizleRole> roleManager, SignInManager<VesizleUser> signInManager, IUserDal userDal, IRoleDal roleDal)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userDal = userDal;
            _roleDal = roleDal;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userDal.GetUsers();
            var roles = _roleDal.GetRoles();

            UserListViewModel model = new UserListViewModel();
            foreach (var user in users)
            {
                user.CurrentRoles = (List<string>)(await _userManager.GetRolesAsync(new VesizleUser() { Id = user.Id, UserName = user.UserName }));
                user.SelectRoles = _mapper.Map<List<SelectListItem>>(roles.Where(role => !user.CurrentRoles.Contains(role.Name)));
            }

            model.Users = users;

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
