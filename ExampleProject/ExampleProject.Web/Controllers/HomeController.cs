using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataRetrievalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExampleProject.Web.Models;

namespace ExampleProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRetrievalService _dataRetrievalService;

        public HomeController(ILogger<HomeController> logger, IDataRetrievalService dataRetrievalService)
        {
            _logger = logger;
            _dataRetrievalService = dataRetrievalService;
        }

        public IActionResult Index()
        {
            var data = _dataRetrievalService.GetVehicles();

            return View("Index", data);
        }

        public IActionResult NewPage([FromQuery] Guid id)
        {
            var data = _dataRetrievalService.GetVehicle(id);
            return View("NewPage", data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}