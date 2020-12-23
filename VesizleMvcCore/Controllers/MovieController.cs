using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.Api.Abstract;

namespace VesizleMvcCore.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        private IMapper _mapper;
        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _movieService.GetDetailsAsync(id);
            if (result.IsSuccessful)
            {
                var resMap = _mapper.Map<MovieDetailsViewModel>(result.Data);
                return View(resMap);
            }
            return View(new MovieDetailsViewModel(){Title="Böyle bir şey yok.."});
        }
    }
}
