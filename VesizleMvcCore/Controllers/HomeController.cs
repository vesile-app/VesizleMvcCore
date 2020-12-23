using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using VesizleMvcCore.NodejsApi.ApiResults;

namespace VesizleMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private ISearchService _searchService;
        private IMovieService _movieService;
        private IMapper _mapper;
        public HomeController(ISearchService searchService, IMovieService movieService, IMapper mapper)
        {
            _searchService = searchService;
            _movieService = movieService;
            _mapper = mapper;
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
        public async Task<ActionResult> Index(string query, int page = 1)
        {
            var result = await _searchService.SearchAsync(query);

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
