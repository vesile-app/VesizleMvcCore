using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Extensions;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Identity.Entities;
using VesizleMvcCore.Models;
using VesizleMvcCore.Models.Dto;
using VesizleMvcCore.NodejsApi.Api;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using VesizleMvcCore.NodejsApi.ApiResults.Results;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        private IMapper _mapper;
        private UserManager<VesizleUser> _userManager;
        private IPasswordHasher<VesizleUser> _passwordHasher;
        private IPasswordValidator<VesizleUser> _passwordValidator;
        private SignInManager<VesizleUser> _signInManager;
        private IMovieService _movieService;

        public ProfileController(SignInManager<VesizleUser> signInManager, IPasswordValidator<VesizleUser> passwordValidator, IPasswordHasher<VesizleUser> passwordHasher, UserManager<VesizleUser> userManager, IMapper mapper, IMovieService movieService)
        {
            _signInManager = signInManager;
            _passwordValidator = passwordValidator;
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            _mapper = mapper;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.FavoriteAsync(HttpContext.User, new Favorite() { MovieId = 733317 });
            var currentUser = _mapper.Map<UserDetailViewModel>(user);
            return View(currentUser);
        }
        [HttpGet]
        public async Task<IActionResult> WatchList()
        {
            var watchList = await _userManager.GetWatchListAsync(HttpContext.User);
            WatchListViewModel watchListViewModel = new WatchListViewModel();

            if (watchList != null)
            {
                foreach (var watch in watchList)
                {
                    var result = await _movieService.GetDetailsAsync(watch.MovieId);
                    if (result.IsSuccessful)
                    {
                        watchListViewModel.WatchListDetailViewModels.Add(_mapper.Map<WatchListDetailViewModel>(result.Data));
                    }
                }
                //WebServis Request
                var userId = _userManager.GetUserId(HttpContext.User);
                CountWebServiceSoapClient client = new CountWebServiceSoapClient(CountWebServiceSoapClient.EndpointConfiguration.CountWebServiceSoap);
                var response = await client.WatchListCountAsync(userId);
                watchListViewModel.Count = response.Body.WatchListCountResult;

            }
            return View(watchListViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> WatchedList()
        {
            var watchedList = await _userManager.GetWatchedListAsync(HttpContext.User);
            WatchedListViewModel watchedListViewModel = new WatchedListViewModel();

            if (watchedList != null)
            {
                foreach (var watched in watchedList)
                {
                    var result = await _movieService.GetDetailsAsync(watched.MovieId);
                    if (result.IsSuccessful)
                    {
                        watchedListViewModel.WatchedListDetailViewModels.Add(_mapper.Map<WatchedListDetailViewModel>(result.Data));
                    }
                }
                //WebServis Request
                var userId = _userManager.GetUserId(HttpContext.User);
                CountWebServiceSoapClient client = new CountWebServiceSoapClient(CountWebServiceSoapClient.EndpointConfiguration.CountWebServiceSoap);
                var response = await client.WatchedListCountAsync(userId);
                watchedListViewModel.Count = response.Body.WatchedListCountResult;
            }
            return View(watchedListViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var favorites = await _userManager.GetFavoritesAsync(HttpContext.User);
            FavoriteListViewModel favoriteListViewModels = new FavoriteListViewModel();

            if (favorites != null)
            {
                foreach (var favorite in favorites)
                {
                    var result = await _movieService.GetDetailsAsync(favorite.MovieId);
                    if (result.IsSuccessful)
                    {
                        favoriteListViewModels.FavoriteDetailViewModels.Add(_mapper.Map<FavoriteDetailViewModel>(result.Data));
                    }
                }
                //WebServis Request
                var userId = _userManager.GetUserId(HttpContext.User);
                CountWebServiceSoapClient client = new CountWebServiceSoapClient(CountWebServiceSoapClient.EndpointConfiguration.CountWebServiceSoap);
                var response = await client.FavoriteCountAsync(userId);
                favoriteListViewModels.Count = response.Body.FavoriteCountResult;
            }
            return View(favoriteListViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Required] string id)
        {
            VesizleUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    return Ok();
                }
                return BadRequest(result.Errors);
            }
            return View("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateViewModel model)
        {
            //todo:validator
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index");
                }
                return BadRequest(result.Errors);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IDataResult<object>> AddFavorite([Required] int movieId)
        {
            var result = await _userManager.FavoriteAsync(HttpContext.User, new Favorite { MovieId = movieId });
            if (result.Data.Succeeded)
            {
                return new SuccessDataResult<object>(message: result.Message, null);
            }

            return new ErrorDataResult<object>(Messages.ThereWasAnError, result.Data.Errors);
        }
        [HttpPost]
        public async Task<object> AddWatchList([Required] int movieId)
        {
            //todo:modelstate validasyon
            var result = await _userManager.WatchListAsync(HttpContext.User, new WatchList { MovieId = movieId });
            if (result.Data.Succeeded)
            {
                return new SuccessDataResult<object>(message: result.Message, null);
            }

            return new ErrorDataResult<object>(Messages.ThereWasAnError, result.Data.Errors);
        }
        [HttpPost]
        public async Task<object> AddWatchedList([Required] int movieId)
        {
            var result = await _userManager.WatchedListAsync(HttpContext.User, new WatchedList { MovieId = movieId });
            if (result.Data.Succeeded)
            {
                return new SuccessDataResult<object>(message: result.Message, null);
            }

            return new ErrorDataResult<object>(Messages.ThereWasAnError, result.Data.Errors);
        }
        [HttpPost]
        public async Task<object> AddReminder(ReminderDto dto)
        {
            var reminder = _mapper.Map<Reminder>(dto);
            var result = await _userManager.ReminderAsync(HttpContext.User, reminder);
            if (result.Succeeded)
            {
                return new SuccessDataResult<object>(message: Messages.AddFavoriteSuccess, null);
            }

            return new ErrorDataResult<object>(Messages.ThereWasAnError, result.Errors);
        }

        [HttpGet]
        public async Task<bool> IsFavorite([Required] int movieId)
        {
            return await _userManager.IsFavoriteAsync(HttpContext.User, movieId);
        }
        [HttpGet]
        [Authorize]
        public async Task<bool> IsWatchList([Required] int movieId)
        {
            return await _userManager.IsWatchListAsync(HttpContext.User, movieId);
        }
        [HttpGet]
        public async Task<bool> IsWatchedList([Required] int movieId)
        {
            return await _userManager.IsWatchedListAsync(HttpContext.User, movieId);
        }
        [HttpGet]
        public async Task<bool> IsReminder([Required] int movieId)
        {
            return await _userManager.IsReminderAsync(HttpContext.User, movieId);
        }
    }
}
