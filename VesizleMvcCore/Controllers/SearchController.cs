using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.Api.Abstract;

namespace VesizleMvcCore.Controllers
{
    public class SearchController : Controller {
        private ISearchService _searchService;
        private IMapper _mapper;

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string query, int page = 1)
        {
            var result = await _searchService.SearchAsync(query);

            var searchDetail = _mapper.Map<SearchViewModel>(result);
            return View(searchDetail);
        }
    }
}


