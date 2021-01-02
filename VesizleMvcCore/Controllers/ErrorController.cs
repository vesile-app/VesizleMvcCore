using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VesizleMvcCore.Models;

namespace VesizleMvcCore.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return RedirectToAction("NotFound");
                case 500:
                    return RedirectToAction("InternalServerError");
                case 403:
                    return RedirectToAction("AccessDenied");
                default:
                    return RedirectToAction("ErrorWithModel", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public new IActionResult NotFound()
        {
            return View();
        }
        [HttpGet]
        public IActionResult InternalServerError()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ErrorWithModel(ErrorViewModel model)
        {
            return View(model);
        }
    }
}
