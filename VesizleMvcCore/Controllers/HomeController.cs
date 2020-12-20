﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public HomeController(ISearchService searchService, IMovieService movieService)
        {
            _searchService = searchService;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View(new ApiSearchResult());
        }
        [HttpPost]
        public async Task<ActionResult> Index(string query, int page = 1)
        {
            var result = await _searchService.SearchAsync(query);

            return View(result);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
