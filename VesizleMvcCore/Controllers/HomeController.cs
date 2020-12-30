using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Extensions;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Identity.Entities;
using VesizleMvcCore.Models;
using VesizleMvcCore.Models.Dto;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using VesizleMvcCore.NodejsApi.ApiResults;
using VesizleMvcCore.NodejsApi.ApiResults.Results;

namespace VesizleMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private ISearchService _searchService;
        private IMovieService _movieService;
        private IMapper _mapper;
        private UserManager<VesizleUser> _userManager;
        public HomeController(ISearchService searchService, IMovieService movieService, IMapper mapper, UserManager<VesizleUser> userManager)
        {
            _searchService = searchService;
            _movieService = movieService;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            var popularAsync = await _movieService.GetPopularAsync();
            var discoverAsync = await _movieService.GetDiscoverAsync();

            model.PopularMovies = _mapper.Map<List<PopularCardModel>>(popularAsync.Results);
            model.DiscoveryMovies = _mapper.Map<List<DiscoverCardModel>>(discoverAsync.Results);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string query)
        {
            return RedirectToAction("Index", "Search", new { query});
        }
       
    }
}
