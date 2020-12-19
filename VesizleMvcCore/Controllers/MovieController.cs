using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VesizleMvcCore.NodejsApi.Api.Abstract;

namespace VesizleMvcCore.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
       
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _movieService.GetDetailsAsync(id);
            return View(result);
        }
    }
}
