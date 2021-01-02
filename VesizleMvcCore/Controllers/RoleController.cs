using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace VesizleMvcCore.Controllers
{
    [Authorize(Roles = "Manager")]
    public class RoleController : Controller
    {
        private RoleManager<VesizleRole> _roleManager;
        private IMapper _mapper;

        public RoleController(RoleManager<VesizleRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            RoleListViewModel viewModel = new RoleListViewModel
            {
                RoleDetailViewModels = _mapper.Map<List<RoleDetailViewModel>>(_roleManager.Roles.ToList())
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityRole = _mapper.Map<VesizleRole>(model);
                var identityResult = await _roleManager.CreateAsync(identityRole);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var identityRole = _mapper.Map<RoleDeleteViewModel>(role);
                return View(identityRole);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(RoleDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddIdentityError("Id", result.Errors);
                }
                return NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var identityRole = _mapper.Map<RoleEditViewModel>(role);
                return View(identityRole);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role != null)
                {
                    role.Name = model.Name;
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddIdentityError(nameof(model.Name), result.Errors);
                }
                return NotFound();
            }
            return View(model);
        }
    }
}
